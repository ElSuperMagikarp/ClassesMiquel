# Store Project
- [x] SQL
    - [ ] Falta Usuari
    - [ ] Falta Descompte
- [x] Fitxer configuració
- [x] Fitxer de projecte
- [x] Programa principal
- [x] Services
    - [x] Database connection
- [x] Model
    - [x] Producte
    - [x] Familia Producte
    - [x] Carrito de compra
        - [ ] Afegir Id Usuari
    - [x] Relació Producte-Carrito
    - [ ] Usuari
        - [ ] IUsuari
        - [ ] Usuari Normal
        - [ ] Usuari Premium
    - [x] Descompte
        - [x] IDescompte
        - [x] Descompte Normal
        - [x] Descompte Premium
- [ ] Repository
    - [x] Producte ADO
    - [x] Familia Producte ADO
    - [x] Carrito de compra ADO
    - [x] Relació Producte-Carrito ADO
- [ ] EndPoints
    - [x] Producte
    - [x] Familia Producte
    - [/] Carrito de compra
        - [ ] carro/{id}/import
        - [ ] QueryString import
    - [ ] Relació Producte-Carrito
- [ ] Peticións Postman
    - [ ] Producte
    - [ ] Familia Producte
    - [ ] Carrito de compra
- [ ] DTO
    - [ ] Producte Response
    - [ ] Producte Request
    - [ ] Familia Response
    - [ ] Familia Request
    - [ ] Carrito Response
    - [ ] Carrito Request
- [ ] Validators
    - [ ] Producte
    - [ ] Familia Producte
    - [ ] Carrito de compra
- [ ] Factories
    - [ ] Descompte
- [ ] **ALTRES**
    - [ ] Canviar EndPoints a una classe central (per fer MapEndpoints)
    - [ ] Common
        - [ ] Result
    - [ ] Posar rols
    - [ ] Afegir versió als Endpoint

## DUBTES
- [x] No es pot fer GET dels productes del carrito -> S'hauria de fer, pero no fa falta
- [x] Preguntar com fer el DELETE de ShoppingCart (EndPoint) -> DELETE /shoppingCartProduct/{id} a Endpoint ShoppingCartProduct


## DISCOUNT

IDiscount:
- calcularDte()

PremiumDiscount:
- dte1 -> float (0.1)
- dte2 -> float (0.08 si import > 1000)

NormalDiscount:
- dte1 -> float (0.1 si import > 3000 o 0.15 si > 7000)