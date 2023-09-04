using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SupremTech.Domain
{

    [Table("Customers")]
    public class Customers
    {
        [Key]

        [JsonIgnore]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }


        public Customers()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PasswordHash = string.Empty;
            Address = string.Empty;
        }
    }
}