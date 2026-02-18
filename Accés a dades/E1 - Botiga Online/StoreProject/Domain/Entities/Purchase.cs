namespace StoreProject.Domain.Entities;

public class Purchase
{
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }
    public List<ProductLine>? ProductLines { get; set; }
}