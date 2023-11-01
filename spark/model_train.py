from pyspark.sql import SparkSession
from pyspark.sql import functions as F
from pyspark.ml.fpm import FPGrowth

sdf_orders = spark.read.option("multiline","true").json("gs://lz-order-compact-02/*.json")

sdf_orders_exploded = sdf_orders.select(F.col("CustomerId"), F.col("OrderNumber"), F.explode(F.col("LineItems")).alias("LineItem"))
sdf_orders_exploded = sdf_orders_exploded.select("CustomerId", "OrderNumber", "LineItem.TypeId", "LineItem.ProductNumber", "LineItem.Name", "LineItem.Price.Value", "LineItem.Price.Discounted", "LineItem.AddedAt", "LineItem.Availability.IsOnStock")

sdf_orders_fp = sdf_orders_exploded.filter(sdf_orders_exploded.TypeId != 'SparePart').groupBy("OrderNumber").agg(F.collect_set("ProductNumber").alias("SalesNumbers"))

fpGrowth = FPGrowth(itemsCol="SalesNumbers", minConfidence=0.2, minSupport=0.01)
model = fpGrowth.fit(sdf_orders_fp)

model.save('gs://lz-gcs/fp_growth_orders_05')
