# Product  

### POST | Insert
``` JSON
// POST http://localhost:5000/products
{
    "familyId" : "familyId 1",
    "code" : "codi1",
    "name" : "Nom Producte 1",
    "price" : 1,
    "discount" : 2
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
    "familyId" : "UPDATED familyId",
    "code": "UPDATED codi",
    "name": "UPDATED Nom Producte",
    "price": 999,
    "discount" : 50
}
```  

### DELETE
``` JSON
// DELETE hhttp://localhost:5000/products/{id}
```  
  
<br><br>
  
# Product Family
### POST | Insert
``` JSON
// POST http://localhost:5000/productfamilies
{
    "name" : "Nom Familia"
}
```  

### GET | Get All & Get by Id
``` JSON
// GET http://localhost:5000/productfamilies
// GET http://localhost:5000/productfamilies/{id}
```  

### PUT | Update
``` JSON
// PUT http://localhost:5000/productfamilies/{id}
{
    "name": "UPDATED Nom Familia"
}
```  

### DELETE
``` JSON
// DELETE http://localhost:5000/productfamilies/{id}
```  
  
<br><br>
  
# Shopping Cart
### POST | Insert
``` JSON
// POST http://localhost:5000/productfamilies

// No fa falta cos, perque només té una ID i es genera automàticament
```  
### POST | Afegir Producte a Carro
``` JSON
// POST http://localhost:5000/shoppingCarts/{id}/add

{
    "productId" : "producteId"
}
```  