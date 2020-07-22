SELECT
    PARTY_ID,
    PARTY_NAME,
    WH_ID,
    PRODUCT_NO,
    PRODUCT_SEQ_NO,
    PRODUCT_NAME,
    PRODUCT_TYPE_ID,
    CASE ("PRODUCT_TYPE_ID")
    WHEN "H" THEN "HOR"
    WHEN "V" THEN "VER"
    WHEN "T" THEN "TAM"
    ELSE "PRS"
    END AS PRODUCT_TYPE_NAME,
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
WHERE  (STATUS = @strS1) or (STATUS = @strS2) or (STATUS = @strS3)
GROUP BY PARTY_ID,
         PARTY_NAME,
         WH_ID,
         PRODUCT_NO,
         PRODUCT_SEQ_NO,
         PRODUCT_NAME,
         PRODUCT_TYPE_ID,
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