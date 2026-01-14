using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Discounts;

public class PremiumDiscount : IDiscount
{
    public float calculateDiscount(double import)
    {
        float descompte = 0.1f;

        if (import > 1000)
        {
            descompte = 0.08f;
            return descompte;
        }

        return descompte;
    }
}