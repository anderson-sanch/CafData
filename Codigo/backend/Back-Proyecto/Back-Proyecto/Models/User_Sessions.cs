using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class User_Sessions // User_Sesions class representing user session entities
    {
        [Key]
        public Guid Id_Session { get; set; } // Primary Key 
        public Guid User_Id { get; set; } // Foreign key to Users
        public string Token { get; set; } // Session token
        public DateTime Start_Date { get; set; } // Session start date
        public DateTime End_Date { get; set; } // Session end date
        public string Status { get; set; } // Session status (e.g., Active, Inactive)
        public Users User { get; set; } // Navigation property for related Users


    }
}
