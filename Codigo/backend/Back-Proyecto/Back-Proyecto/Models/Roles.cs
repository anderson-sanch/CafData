using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Roles // Roles class representing role entities

    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate value
        public Guid Role_Id { get; set; } = Guid.NewGuid(); // Initialize with a new GUID
        public string Name { get; set; } // Role name
        public string Description { get; set; } // Role description

        // Navigation property
        public ICollection<Users> Users { get; set; } // Navigation property for related Users
        public ICollection<Permissions> Permissions { get; set; } // Navigation property for related Permissions


    }
}
