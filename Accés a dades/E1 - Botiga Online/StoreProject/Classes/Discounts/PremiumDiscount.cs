using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Discounts;

public class PremiumDiscount : IDiscount
{
    public decimal calculateDiscount(decimal import)
    {
        decimal descompte = 25;

        if (import >= 40)
        {
            descompte = 50;
            return descompte;
        }

        return descompte;
    }
}