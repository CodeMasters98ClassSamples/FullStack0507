namespace FullStack0507.MyDomain.Entities.OrderContext.OrderAggregate;

public class OrderHistory
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
