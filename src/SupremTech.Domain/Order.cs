using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupremTech.Domain
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public string? OrderStatus { get; set; }

        public virtual Customers Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
