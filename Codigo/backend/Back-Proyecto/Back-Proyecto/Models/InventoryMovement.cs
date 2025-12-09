using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    [Table("Inventory_Movement")]
    public class InventoryMovement

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Movement_Id { get; set; }

        [Required]
        public Guid Product_Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Type_Movement { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Reason { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date_Movement { get; set; }
         
        [Required]
        public Guid User_Id { get; set; }
        

        [ForeignKey(nameof(Product_Id))]
        public Products Product { get; set; }

        [ForeignKey(nameof(User_Id))]
        public Users User { get; set; }
    }
}
