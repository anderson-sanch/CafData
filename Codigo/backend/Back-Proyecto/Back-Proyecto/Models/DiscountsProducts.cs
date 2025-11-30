using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    [Table("Discounted_Products")]
    public class DiscountedProducts
    {
        [Key, Column(Order = 1)]
        public Guid Product_Id { get; set; }

        [Key, Column(Order = 2)]
        public Guid Global_Id { get; set; }

        // Navigation (opcionales)
        public Products? Product { get; set; }
        public GlobalDiscounts? GlobalDiscount { get; set; }
    }
}
