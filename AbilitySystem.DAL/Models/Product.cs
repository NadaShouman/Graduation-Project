using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class Product
{
    public int ProductId { get; set; }
    public int Name { get; set; }
    public float Price { get; set; }
    public int Sale { get; set; }
    public string? Description { get; set; }

    public int Quantity { get; set; }

    public string? ImgURL { get; set; }

    public string? Category { get; set; }//navigational property

    public ICollection<WishList> Wishlists { get; set; } = new HashSet<WishList>();

    public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
}
