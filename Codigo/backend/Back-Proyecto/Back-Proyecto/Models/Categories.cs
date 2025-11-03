using System.ComponentModel.DataAnnotations;     
using System.ComponentModel.DataAnnotations.Schema; 


namespace Back_Proyecto.Models
{
    public class Catogories

    {
        [Key]
        public Guid Category_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }

    }
}
