using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace FullStack0507.MyDomain.Entities.OrderContext.OrderAggregate;

public class Order
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int Otp { get; set; }
    public DateTime OrderedAt { get; set; }
    public string Address { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public List<OrderHistory> Histories { get; set; }

    public List<OrderDetail> Details { get; set; }


    public void Create()
    {
        //...
        Histories.Add(new OrderHistory()
        {
            Status = OrderStatus.PENDING,
        });
    }

}
