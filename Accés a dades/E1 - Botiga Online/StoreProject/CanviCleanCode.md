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
- [ ] Compra Request _(Infraestructure/DTO)_
  - [ ] Usuari (Guid)
  - [ ] Data (Date)
  - [ ] Array Línea Producte
- [ ] Línea Producte (Request) _(Infraestructure/DTO)_
  - [ ] Producte (Guid)
  - [ ] Quantitat (int)
- [ ] Endpoint Compra
  - [ ] Usuari
  - [ ] Llista Productes (Codi, Quantitat)
  - [ ] Data de compra
- [ ] Taula Nova Preus-Producte
  - [ ] Id
  - [ ] IdProducte
  - [ ] Preu
  - [ ] Data
- [ ] Taula Carro (Servirá de compra)
  - [X] Id (ja la té)
  - [ ] Data

**Exemple JSON Compra**
``` json
{
  "usuari": "guidClient",
  "data": "data",
  "productes": [
      {
        "id": "guidProducte",
        "quantitat": 3
      },
      {
        "id": "guidProducte",
        "quantitat": 1
      }
  ]
}
```