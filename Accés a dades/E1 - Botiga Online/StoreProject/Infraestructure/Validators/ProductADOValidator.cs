using StoreProject.Infraestructure.Common;
using StoreProject.Infraestructure.DTO;
using StoreProject.Infraestructure.Persistance.Repository;
using StoreProject.Infraestructure.Services;

namespace StoreProject.Infraestructure.Validators;

public static class ProductADOValidator
{
    public static Result Validate(ProductRequest product, DatabaseConnection dbConn)
    {
        if (ProductADO.CodeExists(dbConn, product.Code))
        {
            return Result.Failure("Ja existeix un producte amb aquest codi", "CODE_DUPLICAT");
        }

        if (ProductADO.NameExists(dbConn, product.Name))
        {
            return Result.Failure("Ja existeix un producte amb aquest nom", "NOM_DUPLICAT");
        }

        if (!ProductFamilyADO.ProductFamilyExists(dbConn, product.FamilyId))
        {
            return Result.Failure("No existeix una familia de producte amb aquest id", "PRODUCTFAMILY_NOTFOUND");
        }

        return Result.Ok();
    }

}
