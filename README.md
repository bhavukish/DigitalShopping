This API will compute the points and discount for shopping cart of Digital market.

The API will be available at http://localhost:5240.

Use Swagger at /swagger when running in Development.
http://localhost:5240/swagger/index.html

Sample Data
{
  "customerId": "8e4e8991-aaee-495b-9f24-52d5d0e509c5",
  "loyaltyCard": "CTX0000001",
  "transactionDate": "03-Apr-2020",
  "basket": [
  {
      "ProductId": "PRD01",
      "UnitPrice": "1.2",
      "Quantity": "3"
    },
    {
      "ProductId": "PRD02",
      "UnitPrice": "2.0",
      "Quantity": "2"
    },
    {
      "ProductId": "PRD03",
      "UnitPrice": "5.0",
      "Quantity": "1"
    }
  ]
}

## Notes / Assumptions
- Date parsing accepts `yyyy-MM-dd` and `dd-MMM-yyyy`.
- Only one points promo can be active at a time (per spec).
- Discount promotions apply only to listed discounted products.
- Data is read from local JSON files in `SampleData/`.

