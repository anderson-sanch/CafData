using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Back_Proyecto.Models
{
    public class Roles // Roles class representing role entities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Rol_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;// Role name
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty; // Role description

        // Navigation property
        public ICollection<Users> Users { get; set; } = new List<Users>(); // Navigation property for related Users
        public ICollection<RolesPermissions> Roles_Permissions { get; set; } = new List<RolesPermissions>(); // Navigation property for related Permissions


    }
}


