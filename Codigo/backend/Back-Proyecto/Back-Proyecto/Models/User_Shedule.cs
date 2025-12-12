using System;
using System.ComponentModel.DataAnnotations;

namespace Back_Proyecto.Models
{
    public class User_Schedule
    {
        [Key]
        public Guid Schedules_Id { get; set; }

        public Guid User_Id { get; set; }

        public TimeSpan Check_In_Time { get; set; }

        public TimeSpan Check_Out_Time { get; set; }

        public string Weekday { get; set; }

        public Users User { get; set; }
    }
}
