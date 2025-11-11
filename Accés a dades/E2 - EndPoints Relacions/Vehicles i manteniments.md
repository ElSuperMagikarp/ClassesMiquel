# 1. Vehicles i manteniments

- **Vehicles:**
    - Id (uniqueidentifier - no significatiu)
    - Matrícula
    - Model
    - Propietari (uniqueidentifier)

- **Manteniments:**
    - Id (uniqueidentifier - no significatiu)
    - IdVehicle (uniqueidentifier)
    - Data.  

- **Treballador:**
    - Id (uniqueidentifier - no signaficatiu)
    - NSS
    - Nom
    - Categoria.

- **Hores - Treballador (Registre):**
    - Id (uniqueidentifier - no signaficatiu)
    - IdTreballador
    - IdManteniment
    - PreuHora
    - QuantitatHores.

## Funcionalitats

> ## Plantilla  
>**Context:** Context  
>**Es fa sobre:** Sobre  
>**EndPoint:** `VERB /url/`  
>**Json:**
>``` JSON
>    {
>        "propietat" : "PROPIETAT"
>    }
>```

### Donar d'alta un vehicle a la base de dades.

**Context:** Vehicles  
**Es fa sobre:** Vehicles  
**EndPoint:** `POST /vehicles/`  
**Json:**
``` JSON
    {
        "matricula" : "MATRICULA",
        "model" : "MODEL",
        "propietari" : "IDPROPIETARI"
    }
```

### Crear un manteniment pel vehicle X. L'usuari obrirà la fitxa del vehicle i polsarà sobre el botó "Afegir" associat a la funcionalitat de manteniments.

**Context:** Vehicles  
**Es fa sobre:** Manteniments  
**EndPoint:** `POST /vehicles/{id}/manteniments/`  
**Json:**
``` JSON
    {
        "data" : "DATA"
    }
```

### Modificar les hores d'un determinat manteniment. L'usuari seleccionarà el manteniment de la llista de manteniments associats a un vehicle i indicarà el total d'hores que s'hi vol imputar.

**Context:** Hores - Treballador (Registre)  
**Es fa sobre:** Hores - Treballador (Registre)  
**EndPoint:** `PATCH /registres/{id}/`  
**Json:**
``` JSON
    {
        "quantitatHores" : 10
    }
```

### Llistar tots els manteniments d'un vehicle.

**Context:** Vehicles  
**Es fa sobre:** Manteniments  
**EndPoint:** `GET /vehicles/{id}/manteniments/`  

### Crear un nou treballador. 

**Context:** Treballadors  
**Es fa sobre:** Treballadors  
**EndPoint:** `POST /treballadors/`  
**Json:**
``` JSON
    {
        "nss" : "NSS",
        "nom" : "NOM",
        "categoria" : "CATEGORIA"
    }
```

### Obtenir l'import d'un manteniment.  

**Context:** Manteniments  
**Es fa sobre:** Manteniments  
**EndPoint:** `GET /manteniments/{id}/import`

### Obtenir l'import de tots els manteniments que s'han fet a un vehicle.  

**Context:** Vehicles  
**Es fa sobre:** Manteniments  
**EndPoint:** `GET /vehicles/{id}/manteniments/import`

### Obtenir totes les hores treballades per un treballador.

**Context:** Treballadors  
**Es fa sobre:** Hores - Treballador (Registre)  
**EndPoint:** `GET /treballadors/{id}/totalHores`

### Llistar tots els manteniments en què ha participat un treballador

**Context:** Treballadors  
**Es fa sobre:** Manteniments  
**EndPoint:** `GET /treballadors/{id}/manteniments`

### Obtenir el cost total d’un treballador (hores × preu).

**Context:** Treballadors  
**Es fa sobre:** Hores - Treballador (Registre)  
**EndPoint:** `GET /treballadors/{id}/cost`

### Consultar tots els treballadors assignats a un manteniment.

**Context:** Manteniments  
**Es fa sobre:** Treballadors  
**EndPoint:** `GET /manteniments/{id}/treballadors`

### Canviar el propietari d’un vehicle.

**Context:** Vehicles  
**Es fa sobre:** Vehicles  
**EndPoint:** `PATCH /vehicles/{id}/`  
**Json:**
``` JSON
    {
        "propietari" : "IDPROPIETARI"
    }
```

### Actualitzar dades d’un treballador.  

**Context:** Treballadors  
**Es fa sobre:** Treballadors  
**EndPoint:** `PUT /treballadors/{id}`  
**Json:**
``` JSON
    {
        "nss" : "NSS",
        "nom" : "NOM",
        "categoria" : "CATEGORIA"
    }
```

### Incrementar el preu hora associat a un treballador.

**Context:** Treballadors  
**Es fa sobre:** Hores - Treballador (Registre)  
**EndPoint:** `PATCH /treballadors/{id}/registres`  
**Json:**
``` JSON
    {
        "incrementPreuHora" : 10
    }
```

## Tasca

- Per a cada funcionalitat cal:

    - Especificar l'entitat context.

    - Especificar l'entitat sobre la qual passa l'acció.  

    - Especificar l'end point a aplicar amb tota la informació associada al mateix