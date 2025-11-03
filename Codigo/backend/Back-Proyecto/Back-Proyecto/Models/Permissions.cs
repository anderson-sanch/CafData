using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Permissions

    {
        [Key]
        public Guid Permission_Id { get; set; }
        public string Name { get; set; } = string.Empty; // Permission name
        public string Description { get; set; } = string.Empty; //Description of the permission

        public ICollection<Roles_Permissions> Roles_Permissions { get; set; } = new List<Roles_Permissions>(); // Navigation property for related Roles
    }
}
