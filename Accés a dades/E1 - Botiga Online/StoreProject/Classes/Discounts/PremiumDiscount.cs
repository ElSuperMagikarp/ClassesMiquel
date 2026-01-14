using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Discounts;

public class PremiumDiscount : IDiscount
{
    public decimal calculateDiscount(decimal import)
    {
        decimal descompte = 10;

        if (import > 1000)
        {
            descompte = 15;
            return descompte;
        }

        return descompte;
    }
}