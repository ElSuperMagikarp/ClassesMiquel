namespace StoreProject.Infraestructure.Persistance.Entities;

public class ShoppingCart
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }
}