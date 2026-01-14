using StoreProject.Classes;

namespace StoreProject.Helpers;

static class ShoppingCartCalculations
{
    public static decimal CalculateImport(List<ShoppingCartProduct> shoppingCartProducts)
    {
        decimal import = 0;

        foreach (ShoppingCartProduct shoppingCartProduct in shoppingCartProducts)
        {
            decimal productDiscount = shoppingCartProduct.Discount / 100;
            import += shoppingCartProduct.Price * productDiscount * shoppingCartProduct.Quantity;
        }

        return import;
    }
}