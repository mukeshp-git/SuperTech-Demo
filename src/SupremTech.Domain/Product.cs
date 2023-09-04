using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupremTech.Domain
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        public int StockQuantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
