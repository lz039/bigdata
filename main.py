import pyspark as ps
from pyspark.sql import SparkSession
from pyspark.ml.fpm import FPGrowthModel
from flask import Flask, request, jsonify

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

# create a SparkContext
# load saved pipeline model from the folder 'model'
global sc
sc = ps.SparkContext()
global spark
spark = SparkSession.builder.appName("Api").getOrCreate()
global assets_model
assets_model = FPGrowthModel.load("fp_growth_assets_01")
global orders_model
orders_model = FPGrowthModel.load("fp_growth_orders_01")

if __name__ == '__main__':
    # run the Flask RESTful API, make the server publicly available (host='0.0.0.0') on port 8080
    app.run(host='0.0.0.0', port=8080, debug=True)
