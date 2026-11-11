using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack0507.MyDomain.Entities.OrderContext.OrderAggregate;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public decimal CurrentPrice { get; set; }

    public Order Order { get; set; }
}
