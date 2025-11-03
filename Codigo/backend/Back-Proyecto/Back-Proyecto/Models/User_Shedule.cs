using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class User_Shedule
    {
        [Key]
        public Guid Id_Shedule { get; set; }
        public Guid User_Id { get; set; }
        public DateTime Check_Int_Time { get; set; }
        public DateTime Check_Out_Time { get; set; }
        public string Weekday { get; set; }
    }

}
