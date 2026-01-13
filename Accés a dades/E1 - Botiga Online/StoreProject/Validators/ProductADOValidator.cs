namespace StoreProject.Validators;

using StoreProject.Common;
using StoreProject.DTO;
using StoreProject.Repository;
using StoreProject.Services;

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
