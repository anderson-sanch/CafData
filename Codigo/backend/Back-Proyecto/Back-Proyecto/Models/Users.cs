using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Users // Users class representing user entities
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate value

        public Guid User_Id { get; set; } = Guid.NewGuid(); // Initialize with a new GUID
        public string Name { get; set; } // User's full name
        public string Username { get; set; } // Unique username
        public string Password { get; set; } // User's password
        public string Rol_Id { get; set; } // Foreign key to Roles
        public string Status { get; set; } // User's status (e.g., Active, Inactive)
        public DateTime Creattion_Date { get; set; } // Account creation date

        // Navigation property
        public Roles Rol { get; set; } // Navigation property for related Roles
        public ICollection<User_Sesions> User_Sessions { get; set; } // Navigation property for related User_Sesions

    }
}
