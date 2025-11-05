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
```