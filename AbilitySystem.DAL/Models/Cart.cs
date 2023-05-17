using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class Cart
{
    public int UserId { get; set; }

    public int ProductId { get; set; }
    public int ProductQuantity { get; set; }
    public Product? Product { get; set; }
    
    public User? User { get; set; }
}
