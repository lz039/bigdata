using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreForce.Client;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Policy = Polly.Policy;

namespace GoogleFunction
{
    public class SalesforceClient
    {
        private readonly ILogger<SalesforceClient> _logger;
        private readonly AsyncPolicy _unauthorizedPolicy;
        private readonly AsyncRetryPolicy _retryAuthPolicy;
        private readonly HttpClient _getHttpClient;
        private ForceClient _getForceClient;

        public SalesforceClient(
            IHttpClientFactory httpClientFactory,
            ILogger<SalesforceClient> logger,
            IOptions<SalesforceConfiguration> salesforceConfiguration)
        {
            _logger = logger;

            _getHttpClient = httpClientFactory.CreateClient();
            _getHttpClient.Timeout = TimeSpan.FromSeconds(10);

            AsyncRetryPolicy retryPolicy = Policy
                .Handle<TaskCanceledException>()
                .RetryAsync(1);

            _unauthorizedPolicy = Policy
                .Handle<ForceApiException>(faex => faex.Errors?.Any(p => p.ErrorCode == "INVALID_SESSION_ID") == true)
                .RetryAsync(1, onRetryAsync: (exception, retryCount) =>
                {
                    _logger.LogWarning(exception, "Session expired, refreshing token");
                    return CreateNewClientAsync(salesforceConfiguration.Value);
                })
                .WrapAsync(retryPolicy);

            _retryAuthPolicy = Policy
                .Handle<ForceAuthException>()
                .WaitAndRetryAsync(3, retryCount => TimeSpan.FromSeconds(retryCount * 2));

            CreateNewClientAsync(salesforceConfiguration.Value).GetAwaiter().GetResult();
        }

        public Task<T> GetRecordAsync<T>(string sObjectTypeName, string objectId, List<string> fields)
        {
            return _unauthorizedPolicy.ExecuteAsync(() => _getForceClient.GetObjectById<T>(sObjectTypeName, objectId, fields));
        }

        public Task<T> GetRecordAsync<T>(string sObjectTypeName, string externalId, string externalIdFieldName, List<string> fields)
        {
            return _unauthorizedPolicy.ExecuteAsync(() => _getForceClient.GetObjectById<T>(sObjectTypeName, $"{externalIdFieldName}/{externalId}", fields));
        }

        public Task<List<T>> QueryAsync<T>(string queryString, bool includeDeleted)
        {
            return _unauthorizedPolicy.ExecuteAsync(() => _getForceClient.Query<T>(queryString, includeDeleted));
        }

        public Task<T> QuerySingleAsync<T>(string queryString, bool includeDeleted)
        {
            return _unauthorizedPolicy.ExecuteAsync(() => _getForceClient.QuerySingle<T>(queryString, includeDeleted));
        }

        public Task<int> CountQueryAsync(string queryString, bool includeDeleted)
        {
            return _unauthorizedPolicy.ExecuteAsync(() => _getForceClient.CountQuery(queryString, includeDeleted));
        }

        private async Task CreateNewClientAsync(SalesforceConfiguration config)
        {
            AuthenticationClient auth = new(config.ApiVersion);
            try
            {
                await _retryAuthPolicy.ExecuteAsync(()
                    => auth.UsernamePasswordAsync(config.ClientId, config.ClientSecret, config.Username, config.Password, config.TokenRequestEndpoint));
            }
            catch (ForceAuthException ex)
            {
                throw new Exception("Error getting access token", ex);
            }
            catch (JsonReaderException ex)
            {
                throw new Exception("Error getting access token", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting access token", ex);
            }

            _getForceClient = new ForceClient(auth.AccessInfo.InstanceUrl,
                auth.ApiVersion, auth.AccessInfo.AccessToken,
                _getHttpClient, auth.AccessInfo);
        }
    }

    public class SalesforceConfiguration
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ApiVersion { get; set; }

        public string AuthorizationEndpoint { get; set; }

        public string TokenRequestEndpoint { get; set; }

        public string TokenRevocationEndpoint { get; set; }
    }
}
