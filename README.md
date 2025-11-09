## Technologies Used:

- .NET 8
- Entity Framework Core
- SQL Server
- xUnit
- Moq
- FluentAssertions

## Endpoints:

### GET:
*/api/powerplants?owner=petraite&pagenumber=1&pagesize=10*
#### Example response:
```json
{
    "powerPlants": [
        {
            "owner": "Ona Petraitė",
            "power": 12.5,
            "validFrom": "2019-09-10",
            "validTo": null
        }
    ],
    "pageNumber": 1,
    "pageSize": 10
}
```

### POST:
*/api/powerplants*
#### Example request body:
```json
{
    "owner": "Ona Petraitė",
    "power": 100,
    "validFrom": "2021-07-15",
    "validTo": null
}
```
