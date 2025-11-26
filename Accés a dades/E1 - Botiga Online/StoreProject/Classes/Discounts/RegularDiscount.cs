using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Discounts;

public class RegularDiscount : IDiscount
{
    public float calcularDte(double import)
    {
        float descompte = 0;

        if (import > 7000)
        {
            descompte = 0.15f;
            return descompte;
        }
        else if (import > 3000)
        {
            descompte = 0.1f;
            return descompte;
        }

        return descompte;
    }
}