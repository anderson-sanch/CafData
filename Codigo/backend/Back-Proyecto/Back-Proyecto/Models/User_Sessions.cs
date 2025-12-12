using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    
    public class User_Sessions
    {
        [Key]
        public Guid Id_Session { get; set; }

        public Guid User_Id { get; set; }

        public string Token { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime? End_Date { get; set; }  // CORREGIDO

        public string Status { get; set; }

        public Users User { get; set; }
    }

}
