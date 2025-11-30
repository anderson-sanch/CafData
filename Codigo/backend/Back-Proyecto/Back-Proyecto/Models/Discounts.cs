using Back_Proyecto.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Discounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Discount_Id { get; set; }
        [Required]
        public Guid Product_Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string type { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Value { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public bool Active { get; set; }

        public string Description { get; set; }

        public Products? Products { get; set; }
    }
}