using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Global_Discounts

    {
        [Key]
        public Guid Global_Id { get; set; }
        public String Name { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool Status { get; set; }

    }
}
