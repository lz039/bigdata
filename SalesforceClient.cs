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
            string authUrl = config.AuthUrl;
            List<KeyValuePair<string, string>> content = new()
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_id", config.ClientId),
                new KeyValuePair<string, string>("client_secret", config.ClientSecret),
                new KeyValuePair<string, string>("username", config.Username),
                new KeyValuePair<string, string>("password", config.Password)
            };

            using var response = await _getHttpClient.PostAsync(authUrl, new FormUrlEncodedContent(content));
            string stringContent = await response.Content.ReadAsStringAsync();
            SalesforceAuthorizationResponse authResponse = JsonConvert.DeserializeObject<SalesforceAuthorizationResponse>(stringContent);

            _getForceClient = new ForceClient(authResponse.instance_url, config.ApiVersion, authResponse.access_token);
        }
    }

    public class SalesforceAuthorizationResponse
    {
        public string access_token { get; set; }

        public string instance_url { get; set; }

        public string id { get; set; }

        public string token_type { get; set; }

        public string issued_at { get; set; }

        public string signature { get; set; }
    }

    public class SalesforceConfiguration
    {
        public string AuthUrl { get; set; }

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
