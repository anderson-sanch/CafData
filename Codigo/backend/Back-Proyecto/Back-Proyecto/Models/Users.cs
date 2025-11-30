using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Back_Proyecto.Models.Enums;

namespace Back_Proyecto.Models
{
    public class Users // Users class representing user entities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid User_Id { get; set; }
        [Required]
        public string Name { get; set; } // User's full name
        [Required]
        public string Username { get; set; } // Unique username
        [Required]
        public string Password { get; set; } // User's password

        [ForeignKey("Rol")]
        public Guid Rol_Id { get; set; } // Foreign key to Roles
        public Roles? Rol { get; set; } = null; // Navigation property to Roles

        public UserStatus Status { get; set; } // User's status (e.g., Active, Inactive)

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation_Date { get; set; } // Account creation date

        public ICollection<User_Sessions> Sessions { get; set; } = new List<User_Sessions>(); // Navigation property for related User_Sessions

    }
}
