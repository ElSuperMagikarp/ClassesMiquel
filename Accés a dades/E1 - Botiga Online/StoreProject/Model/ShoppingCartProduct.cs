namespace StoreProject.Model;

public class ShoppingCartProduct
{
    public Guid Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}