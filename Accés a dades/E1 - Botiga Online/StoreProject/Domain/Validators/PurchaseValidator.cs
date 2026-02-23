using StoreProject.Infraestructure.Common;
using StoreProject.Infraestructure.DTO;

namespace StoreProject.Validators;

public static class PurchaseValidator
{
    public static Result Validate(PurchaseRequest purchase)
    {
        DateOnly dateNow = DateOnly.FromDateTime(DateTime.Now);
        if (purchase.purchaseDate > dateNow)
        {
            return Result.Failure("PurchaseDate cannot be a future date", "WRONG_DATE");
        }

        if (!purchase.productLines.Any())
        {
            return Result.Failure("There must be at least one Product Line", "WRONG_PRODUCTLINES");
        }

        return Result.Ok();
    }
}
