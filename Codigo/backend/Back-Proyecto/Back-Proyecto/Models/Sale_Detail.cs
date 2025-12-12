using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    [Table("Sale_Detail")]
    public class Sale_Detail

    {
        [Key]
        public Guid Detail_Id { get; set; }
        public Guid Sale_Id { get; set; }
        public Guid Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_Price { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount_Applied { get; set; }
    }
}
