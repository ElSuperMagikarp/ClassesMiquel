namespace StoreProject.Infraestructure.Classes;

public class ShoppingCartProduct
{
    public Guid Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}