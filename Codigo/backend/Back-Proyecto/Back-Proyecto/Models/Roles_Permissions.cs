using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Roles_Permissions // Junction table for many-to-many relationship between Roles and Permissions

    {
        
        public Guid Role_Id { get; set; } // Foreign key to Roles
        public Roles Role { get; set; } = null;// Navigation property for related Role

        public Guid Permission_Id { get; set; } // Foreign key to Permission
        public Permissions Permission { get; set; } = null; // Navigation property for related Permission

    }
}
