import base64
import functions_framework
from google.cloud import storage
import datetime
import pytz
import json

# Triggered from a message on a Cloud Pub/Sub topic.
@functions_framework.cloud_event
def jsoncompaction(cloud_event):  
    bucket_input = "lz-order-01"
    bucket_output = "lz-order-compact-01"

    # daily trigger to compact existing json files
    current_time = datetime.datetime.now()
    threshold_time = current_time - datetime.timedelta(hours=24)
    threshold_time

    utc=pytz.UTC
    threshold_time = utc.localize(threshold_time)
    threshold_time

    client = storage.Client()
    files = list(client.list_blobs(bucket_input))

    combined_data = []        
    for blob in files:
        if blob.time_created >= threshold_time:
            json_data = json.loads(blob.download_as_text())
            combined_data.append(json_data)
            
    # Combine the JSON data into a single list
    combined_json = json.dumps(combined_data, indent=2)

    # Upload the combined JSON to the bucket
    bucket = client.get_bucket(bucket_output)
    combined_blob = bucket.blob(f"{threshold_time.strftime('%Y-%m-%d_%H:%M')}.json")
    combined_blob.upload_from_string(combined_json, content_type='application/json')