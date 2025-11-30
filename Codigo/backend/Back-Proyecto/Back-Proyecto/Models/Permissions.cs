using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Permissions

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Permission_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty; // Permission name
        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = string.Empty; //Description of the permission

        public ICollection<RolesPermissions> Roles_Permissions { get; set; } = new List<RolesPermissions>(); // Navigation property for related Roles
    }
}
