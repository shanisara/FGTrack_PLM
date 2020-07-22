SELECT
    PARTY_ID,
    PARTY_NAME,
    WH_ID,
    ETD_DATE,
    ETD_TIME,
    STATUS,
    RESPONSIBLE,
    MAX(FLAG)
FROM DELIVERY_BOARD
WHERE  UPPER( WH_ID ) LIKE '%' || UPPER( @strWH_ID ) || '%'
GROUP BY PARTY_ID,
         PARTY_NAME,
         WH_ID,
         ETD_DATE,
         ETD_TIME,
         STATUS,
         RESPONSIBLE
;

