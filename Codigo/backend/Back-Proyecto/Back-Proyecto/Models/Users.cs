using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Users // Users class representing user entities
    {
        [Key]
        public Guid User_Id { get; set; }
        public string Name { get; set; } // User's full name
        public string Username { get; set; } // Unique username
        public string Password { get; set; } // User's password
        public Guid Rol_Id { get; set; } // Foreign key to Roles
        public Roles Rol { get; set; } = null; // Navigation property to Roles
        public string Status { get; set; } = "Active"; // User's status (e.g., Active, Inactive)
        public DateTime Creation_Date { get; set; } // Account creation date

        public ICollection<User_Sessions> Sessions { get; set; } = new List<User_Sessions>(); // Navigation property for related User_Sessions

    }
}
