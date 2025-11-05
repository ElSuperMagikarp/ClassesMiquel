# Profile
``` JSON
// POST http://localhost:5000/profiles     --- Inserir un nou perfil
{
    "userId": "USER ID",
    "name": "Profile 1",
    "description": "Profile description 1",
    "isActive": true
}
// GET http://localhost:5000/profiles      --- Obtenir el llistat de tots els perfils
// GET http://localhost:5000/profiles/id    --- Buscar un perfil per id
// PUT http://localhost:5000/profiles/id    --- Actualitzar un perfil
{
    "userId": "USER ID",
    "name": "Profile 2",
    "description": "Profile description 2",
    "isActive": false
}
// DELETE http://localhost:5000/profiles/id --- Eliminar un perfil per id

// POST http://localhost:5000/profiles/profileId/profileImage/profileImageId    --- Posar imatge a perfil
// DELETE http://localhost:5000/profiles/profileId/profileImage/profileImageId  --- Treure imatge de perfil
```
## Profile Image
``` JSON
// POST http://localhost:5000/profileImages --- Pujar imatges de perfil
BODY: form-data
KEY: files (Type: File)
VALUE: Poses els fitxers (tots en un valor. Si ho fas en varis només extreu metadades d'un)
// DELETE http://localhost:5000/profileImages/id
```