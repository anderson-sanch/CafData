using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    [Table("Global_Discounts")]
    public class GlobalDiscounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Global_Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; } // monto | porcentaje

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime Start_Date { get; set; }

        [Required]
        public DateTime End_Date { get; set; }

        [Required]
        public bool Status { get; set; }

        // Navigation
        public ICollection<DiscountedProducts> DiscountedProducts { get; set; }
    }
}
