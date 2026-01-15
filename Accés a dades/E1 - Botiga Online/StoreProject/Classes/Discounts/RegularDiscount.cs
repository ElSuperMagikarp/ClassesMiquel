using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Discounts;

public class RegularDiscount : IDiscount
{
    public decimal calculateDiscount(decimal import)
    {
        decimal descompte = 0;

        if (import >= 40)
        {
            descompte = 25;
            return descompte;
        }

        return descompte;
    }
}