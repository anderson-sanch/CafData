using System.ComponentModel.DataAnnotations;      
using System.ComponentModel.DataAnnotations.Schema; 

namespace Back_Proyecto.Models
{
    public class Clients

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Client_Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string Phone_Number { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Registration_Date { get; set; }
    }
}
