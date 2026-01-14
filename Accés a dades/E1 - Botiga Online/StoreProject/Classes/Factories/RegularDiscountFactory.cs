using StoreProject.Classes.Discounts;
using StoreProject.Classes.Interfaces;

namespace StoreProject.Classes.Factories;

public class RegularDiscountFactory : IDiscountFactory
{
    public IDiscount CreateDiscount()
    {
        return new RegularDiscount();
    }
}