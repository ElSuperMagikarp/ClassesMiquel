using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Discounts;

public class RegularDiscount : IDiscount
{
    public decimal calculateDiscount(decimal import)
    {
        decimal descompte = 0;

        if (import > 7000)
        {
            descompte = 15;
            return descompte;
        }
        else if (import > 3000)
        {
            descompte = 10;
            return descompte;
        }

        return descompte;
    }
}