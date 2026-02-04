- [ ] Classes
  - [ ] Classes Infraestructura (totes les actuals) -> Infraestructure/Classes
  - [ ] Classes Domain (ara mateix cap) -> Domain/Classes
- [ ] Common -> Infraestructure/Common
- [ ] DTO -> Infrastructure/DTO
- [ ] EndPoints -> Application/Endpoints
- [ ] Model -> Infraestructure/Persistence/Entitites
- [ ] Repository -> Infraestructure/Persistance/Repositories
- [ ] Services -> Infraestructure/Services
- [ ] Validators
  - [ ] ValidatorsNormals -> Domain/Validators
  - [ ] ValidadorsADO -> Infraestructure/Validators

## Coses noves
- [ ] Endpoint Compra
  - [ ] Llista Productes (Codi, Quantitat)
  - [ ] Client
- [ ] Taula BD Compra (potser carro)

**Exemple JSON Compra**
``` json
{
    "client": "guidClient",
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

## Dubtes generals
- Que és Infraestructure/Persistance?
  - Persistance == BD/Emmagatzematge