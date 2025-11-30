using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class RolesPermissions // Junction table for many-to-many relationship between Roles and Permissions

    {
        
        public Guid Role_Id { get; set; } // Foreign key to Roles
        public Roles Role { get; set; }// Navigation property for related Role

        public Guid Permission_Id { get; set; } // Foreign key to Permission
        public Permissions Permission { get; set; } // Navigation property for related Permission

    }
}
