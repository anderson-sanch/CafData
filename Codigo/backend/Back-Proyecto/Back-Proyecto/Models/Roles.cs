using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Back_Proyecto.Models
{
    public class Roles // Roles class representing role entities
    {
        [Key]
        public Guid Rol_Id { get; set; }
        public string Name { get; set; } = string.Empty;// Role name
        public string Description { get; set; } = string.Empty; // Role description

        // Navigation property
        public ICollection<Users> Users { get; set; } = new List<Users>(); // Navigation property for related Users
        public ICollection<Roles_Permissions> Roles_Permissions { get; set; } = new List<Roles_Permissions>(); // Navigation property for related Permissions


    }
}


