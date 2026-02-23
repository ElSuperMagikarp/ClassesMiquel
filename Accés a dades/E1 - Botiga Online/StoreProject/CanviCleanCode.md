- [X] Classes
  - [X] Classes Infraestructura (totes les actuals) -> Infraestructure/Classes
  - [X] Classes Domain (ara mateix cap) -> Domain/Classes
- [X] Common -> Infraestructure/Common
- [X] DTO -> Infrastructure/DTO
- [X] EndPoints -> Application/Endpoints
- [X] Model -> Infraestructure/Persistence/Entitites
- [X] Repository -> Infraestructure/Persistance/Repositories
- [X] Services -> Infraestructure/Services
- [X] Validators
  - [X] ValidatorsNormals -> Domain/Validators
  - [X] ValidadorsADO -> Infraestructure/Validators

## Coses noves
- Domain _(Domain/Entities)_
  - [X] Purchase
    - UserId (`Guid`)
    - PurchaseDate (`DateOnly`)
    - ProductLine List (`List<ProductLine>`)
  - [X] ProductLine
    - Producte (`Guid`)
    - Quantitat (`int`)
- Request _(Infraestructure/DTO)_
  - [X] PurchaseRequest
  - [X] ProductLineRequest
- Validators _(Domain/Validators)_
  - [X] Purchase Validator
  - [ ] Product Line Validator
- Mappers _(Infraestructure/Mappers)_
  - [ ] PurchaseMapper
  - [ ] ProductLineMapper
- Endpoint
  - [ ] Compra
    - Usuari
    - Llista Productes (Codi, Quantitat)
    - Data de compra
- BD
  - [ ] Taula Nova Preus-Producte
    - Id
    - IdProducte
    - Preu
    - Data
  - [ ] Taula Carro (Servirá de compra)
    - Id (ja la té)
    - Data

**Exemple JSON Compra**
``` json
{
  "userId": "guidClient",
  "purchaseDate": "data",
  "productLines": [
      {
        "productId": "guidProducte",
        "quantity": 3
      },
      {
        "productId": "guidProducte",
        "quantity": 1
      }
  ]
}
```

### DUBTES
- [ ] Com faig CompraRequest, perque tots els requests que tenim fan ToAlgo i no tinc objecte per fer-ho
- [ ] De la mateixa manera, com Línea Producte, pk en teoria es un request pero no ho entenc
- [ ] Com li trec el preu a producte? Introdueixo productes sense preu i faig un crud apart?
- [ ] Si la taula de carro te data, he de fer CarroRequest?