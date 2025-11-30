using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Products

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Product_Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Min_Stock { get; set; }
        [Required]
        public Guid Category_Id { get; set; }

        public Categories? Categories { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation_Date { get; set; }

    }

}
