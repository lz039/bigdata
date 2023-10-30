import pyspark as ps
from pyspark.sql import SparkSession
from pyspark.ml.fpm import FPGrowthModel
from flask import Flask, request, jsonify
from google.cloud import storage
import os

# create a Flask instance
app = Flask(__name__)

@app.route('/assets', methods=['POST'])
def predictAssets():
    content = request.json
    numbers = content['salesNumbers']

    data = spark.createDataFrame([(1, numbers)]).toDF("id", "SalesNumbers")
    prediction = assets_model.transform(data)
    prediction_label = prediction.select(prediction['prediction']).collect()

    return jsonify({"predictions": prediction_label[0][0] })

@app.route('/orders', methods=['POST'])
def predictOrder():
    content = request.json
    numbers = content['salesNumbers']

    data = spark.createDataFrame([(1, numbers)]).toDF("id", "SalesNumbers")
    prediction = orders_model.transform(data)
    prediction_label = prediction.select(prediction['prediction']).collect()

    return jsonify({"predictions": prediction_label[0][0] })

def loadModelToLocalFs(model_folder):
    client = storage.Client()
    source_bucket_name = 'lz-gcs'
    folder_path = f'{model_folder}/'
    local_directory = model_folder

    bucket = client.bucket(source_bucket_name)
    blobs = list(bucket.list_blobs(prefix=folder_path))

    try:
        os.makedirs(local_directory, exist_ok=True)
        os.makedirs(f'{local_directory}/data/_SUCCESS')
        os.makedirs(f'{local_directory}/metadata/_SUCCESS')
    except FileExistsError:
        print('folder exists')
        return

    for blob in blobs:
        filename = blob.name[len(folder_path):]
        local_path = os.path.join(local_directory, filename)
        try:
            blob.download_to_filename(local_path)
        except IsADirectoryError:
            print('skipping directory')

global sc
sc = ps.SparkContext()
global spark
spark = SparkSession.builder.appName("Api").getOrCreate()
global assets_model
loadModelToLocalFs("fp_growth_assets_01")
assets_model = FPGrowthModel.load("fp_growth_assets_01")
loadModelToLocalFs("fp_growth_orders_01")
global orders_model
orders_model = FPGrowthModel.load("fp_growth_orders_01")

if __name__ == '__main__':
    # run the Flask RESTful API, make the server publicly available (host='0.0.0.0') on port 8080
    app.run(host='0.0.0.0', port=8080, debug=False)
