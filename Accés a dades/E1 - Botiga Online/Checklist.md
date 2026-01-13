# Store Project
- [x] SQL
- [x] Fitxer configuració
- [x] Fitxer de projecte
- [x] Programa principal
- [x] Services
    - [x] Database connection
- [x] Common
    - [x] Result
- [x] Model
    - [x] Producte
    - [x] Familia Producte
    - [x] Carrito de compra
    - [x] Relació Producte-Carrito
    - [x] Descompte
        - [x] IDescompte
        - [x] Descompte Normal
        - [x] Descompte Premium
- [ ] Repository
    - [ ] Producte ADO
      - [ ] Funcions Validator 
    - [x] Familia Producte ADO
    - [x] Carrito de compra ADO
    - [ ] Relació Producte-Carrito ADO
- [ ] EndPoints
    - [x] Producte
    - [x] Familia Producte
    - [ ] Carrito de compra
        - [ ] carro/{id}/import
        - [ ] QueryString import
    - [ ] Relació Producte-Carrito
        - [ ] Patch Quantitat
- [ ] Peticións Postman
    - [ ] Producte
    - [ ] Familia Producte
    - [ ] Carrito de compra
    - [ ] Relació Producte-Carrito
- [ ] DTO
    - [x] Producte Response
    - [x] Producte Request
    - [x] Familia Response
    - [x] Familia Request
    - [ ] Carrito Response
    - [ ] Carrito Request
    - [x] Carrito-Producte Response
    - [x] Carrito-Producte Request
- [ ] Validators
    - [x] Producte
    - [ ] ProducteADO
    - [ ] Familia Producte
    - [ ] Carrito de compra
    - [ ] Carrito-Producte
- [ ] Factories
    - [ ] Descompte
- [ ] **ALTRES**
    - [ ] Canviar EndPoints a una classe central (per fer MapEndpoints)
    - [ ] Posar rols
    - [ ] Afegir versió als Endpoint

## DUBTES


## DISCOUNT

IDiscount:
- calcularDte()

PremiumDiscount:
- dte1 -> float (0.1)
- dte2 -> float (0.08 si import > 1000)

NormalDiscount:
- dte1 -> float (0.1 si import > 3000 o 0.15 si > 7000)