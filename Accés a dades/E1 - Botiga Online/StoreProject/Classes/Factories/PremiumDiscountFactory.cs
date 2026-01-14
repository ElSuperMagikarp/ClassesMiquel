using StoreProject.Classes.Discounts;
using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Factories;

public class PremiumDiscountFactory : IDiscountFactory
{
    public IDiscount CreateDiscount()
    {
        return new PremiumDiscount();
    }
}