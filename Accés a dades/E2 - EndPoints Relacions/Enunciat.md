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

- **Hores - Treballador:**
    - Id (uniqueidentifier - no signaficatiu)
    - IdTreballador
    - IdManteniment
    - PreuHora
    - QuantitatHores.

## Funcionalitats

- Donar d'alta un vehicle a la base de dades.

- Crear un manteniment pel vehicle X. L'usuari obrirà la fitxa del vehicle i polsarà sobre el botó "Afegir" associat a la funcionalitat de manteniments.

- Modificar les hores d'un determinat manteniment. L'usuari seleccionarà el manteniment de la llista de manteniments associats a un vehicle i indicarà el total d'hores que s'hi vol imputar.

- Llistar tots els manteniments d'un vehicle.

- Crear un nou treballador. 

- Obtenir l'import d'un manteniment.  

- Obtenir l'import de tots els manteniments que s'han fet a un vehicle.  

- Obtenir totes les hores treballades per un treballador.

- Llistar tots els manteniments en què ha participat un treballador.

- Obtenir el cost total d’un treballador (hores × preu).

- Assignar un treballador a un manteniment.

- Consultar tots els treballadors assignats a un manteniment.

- Canviar el propietari d’un vehicle.

- Actualitzar dades d’un treballador.  

- Incrementar el preu hora associat a un treballador.

## Tasca

- Per a cada funcionalitat cal:

    - Especificar l'entitat context.

    - Especificar l'entitat sobre la qual passa l'acció.  

    - Especificar l'end point a aplicar amb tota la informació associada al mateix