namespace Back_Proyecto.Models
{
    public class Attendance_Log

    {
        public Guid Attendance_Id { get; set; }
        public Guid User_Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }

    }
}

