using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // la DB ya tiene el GUID (según tu diseño)
        public Guid Category_Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        // Navegación: inicializada para evitar problemas de validación/serialización
        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
