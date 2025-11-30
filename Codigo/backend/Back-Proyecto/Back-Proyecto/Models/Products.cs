using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // la DB genera el GUID si así lo tienes
        public Guid Product_Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int Min_Stock { get; set; }

        // FK exacto que existe en tu tabla
        [Required]
        public Guid Category_Id { get; set; }

        [Required]
        public DateTime Creation_Date { get; set; }

        // Navegación: NOTE el nombre es singular "Category" para que EF relacione con Category_Id
        [ForeignKey(nameof(Category_Id))]
        public Categories Category { get; set; }

        // Si usas Discounts/DiscountedProducts, inicializa la colección
        public ICollection<DiscountedProducts> DiscountedProducts { get; set; } = new List<DiscountedProducts>();

        // Si realmente tienes una entidad Discounts ligada directamente, añade:
        public ICollection<Discounts> Discounts { get; set; } = new List<Discounts>();

    }
}
