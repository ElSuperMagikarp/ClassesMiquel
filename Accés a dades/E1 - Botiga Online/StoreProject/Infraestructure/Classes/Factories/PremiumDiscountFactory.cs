using StoreProject.Infraestructure.Classes.Discounts;
using StoreProject.Infraestructure.Classes.Interfaces;

namespace StoreProject.Infraestructure.Classes.Factories;

public class PremiumDiscountFactory : IDiscountFactory
{
    public IDiscount CreateDiscount()
    {
        return new PremiumDiscount();
    }
}