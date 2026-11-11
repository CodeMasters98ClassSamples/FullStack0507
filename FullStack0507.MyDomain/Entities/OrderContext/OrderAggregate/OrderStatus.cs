using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack0507.MyDomain.Entities.OrderContext.OrderAggregate
{
    public enum OrderStatus
    {
        NONE = 0,
        PENDING = 1,
        APPROVED = 2,
        CANCEL = 3,
        REJECT = 4,
        DONE = 5,
    }
}
