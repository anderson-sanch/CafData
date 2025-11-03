using System.ComponentModel.DataAnnotations;      
using System.ComponentModel.DataAnnotations.Schema; 

namespace Back_Proyecto.Models
{
    public class Clients

    {
        [Key]
        public Guid Client_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public DateTime Registration_Date { get; set; }
    }
}
