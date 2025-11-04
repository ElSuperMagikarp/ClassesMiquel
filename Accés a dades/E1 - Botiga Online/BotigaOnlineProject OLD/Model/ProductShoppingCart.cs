namespace botiga.Model;

public class ProductShoppingCart
{
    public Guid Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public Guid ProductId { get; set; }
    public int quantity { get; set; }
}