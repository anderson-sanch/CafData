using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Attendance_Log

    {
        [Key]
        public Guid Attendance_Id { get; set; }
        public Guid User_Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start_Date { get; set; }
        public TimeSpan? End_Date { get; set; }
        public string Status { get; set; }

        public Users Users { get; set; }

    }
}

