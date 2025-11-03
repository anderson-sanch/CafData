namespace Back_Proyecto.Models
{
    public class System_Log
    {
        public Guid Log_Id { get; set; }
        public Guid User_Id { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }
        public string Module { get; set; }

    }
}
