using System;
using System.ComponentModel.DataAnnotations;

namespace Back_Proyecto.Models
{
    public class System_Log
    {
        [Key]
        public Guid Id_Logs { get; set; }
        public Guid User_Id { get; set; }
        public string Acction { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Module { get; set; }
    }
}
