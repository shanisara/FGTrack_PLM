SELECT
    PARTY_ID,
    PARTY_NAME,
    WH_ID,
    PRODUCT_NO,
    PRODUCT_SEQ_NO,
    PRODUCT_NAME,
    PRODUCT_TYPE_ID,
    PRODUCT_TYPE_NAME,
    BOX_QTY,
    STOCK_PCS,
    STOCK_BOX,
    STATUS_RUNNING_MC,
    PICK_PENDING,
    EXPECTED_DELAY,
    FORECAST,
    MIN_BOX,
    MAX_BOX,
    STATUS,
    MAX(FLAG)
FROM STOCK_BY_MINMAX
WHERE  UPPER( WH_ID ) LIKE '%' || UPPER( @strWH_ID ) || '%'
GROUP BY PARTY_ID,
         PARTY_NAME,
         WH_ID,
         PRODUCT_NO,
         PRODUCT_SEQ_NO,
         PRODUCT_NAME,
         PRODUCT_TYPE_ID,
         PRODUCT_TYPE_NAME,
         BOX_QTY,
         STOCK_PCS,
         STOCK_BOX,
         STATUS_RUNNING_MC,
         PICK_PENDING,
         EXPECTED_DELAY,
         FORECAST,
         MIN_BOX,
         MAX_BOX,
         STATUS
;