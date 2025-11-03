using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Proyecto.Models
{
    public class Products

    {
        [Key]
        public Guid Product_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Min_Stock { get; set; }
        public Guid Category_Id { get; set; }
        public DateTime Creation_Date { get; set; }

    }

}
