using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public OrderStaus OrderStatus { get; set; }

    public DateTime OrderDate { get; set; }

    public float TotalPrice { get; set;}

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();

    public User? User { get; set; } //navigational property


}

public enum OrderStaus
{
    Accepted, 
    Pending,
    Rejected

}
