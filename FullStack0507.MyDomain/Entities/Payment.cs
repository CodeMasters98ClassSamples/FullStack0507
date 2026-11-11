using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack0507.MyDomain.Entities;

public class Payment
{
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsSuccessful { get; set; }
    public string Url { get; set; }
    public DateTime PaidAt { get; set; }
}
