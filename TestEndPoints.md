# Product  

### POST | Insert
``` JSON
// POST http://localhost:5000/products
{
    "familyId" : "familyId 1",
    "code" : "codi1",
    "name" : "Nom Producte 1",
    "price" : 1
}
```  

### GET | Get All & Get by Id
``` JSON
// GET http://localhost:5000/products
// GET http://localhost:5000/products/{id}
```  

### PUT | Update
``` JSON
// PUT http://localhost:5000/products/{id}
{
    "familyId" : "updated familyId",
    "code": "updated codi",
    "name": "updated Nom Producte",
    "price": 999
}
```  

### DELETE
``` JSON
// DELETE hhttp://localhost:5000/products/{id}
```  