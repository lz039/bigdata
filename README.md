# Big Data Architectures

Miro board (protected): https://miro.com/app/board/uXjVMnKP_hc=/

## Product Recommender

Ingress:
- Cloud function (`cloud_functions -> ct_ingress`)
- Performance improvements using JSON compaction (`cloud_functions -> compaction`)

Components:
- FP-Growth model training using spark (`spark -> train_model -> Assets/Orders_Analytics01`)
- REST-API for getting recommendations (`api -> main.py`)

### Example API Calls

IP see Miro.

1. Assets

```
curl --location 'http://{ip}:8080/assets' \
--header 'Content-Type: application/json' \
--data '{
    "salesNumbers": [ "00584159" ]
}'
```

2. Orders
```
curl --location 'http://{ip}:8080/orders' \
--header 'Content-Type: application/json' \
--data '{
    "salesNumbers": [ "205182" ]
}'
```

More example sales numbers see Miro.

## Price comparison

- Util for format fixes (`spark -> price_comparison -> XslToCsv`)
- Aggregration and filtering (`spark -> price_comparison -> Prices`)