using StoreProject.Infraestructure.Common;
using StoreProject.Infraestructure.DTO;

namespace StoreProject.Domain.Validators;

public static class ProductValidator
{
    public static Result Validate(ProductRequest product)
    {
        if (string.IsNullOrEmpty(product.Code))
        {
            return Result.Failure("El codi del producte és obligatori", "DADA_OBLIGATORIA");
        }

        if (string.IsNullOrEmpty(product.Name))
        {
            return Result.Failure("El nom del producte és obligatori", "DADA_OBLIGATORIA");
        }

        if (product.Discount < 0)
        {
            return Result.Failure("El descompte ha de ser com a mínim 0", "DESCOMPTE_INCORRECTE");
        }

        if (product.Discount > 100)
        {
            return Result.Failure("El descompte no pot ser superior a 100", "DESCOMPTE_INCORRECTE");
        }

        return Result.Ok();
    }

}
