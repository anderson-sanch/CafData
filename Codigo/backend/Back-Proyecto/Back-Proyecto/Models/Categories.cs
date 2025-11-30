using System.ComponentModel.DataAnnotations;     
using System.ComponentModel.DataAnnotations.Schema; 


namespace Back_Proyecto.Models
{
    public class Categories

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Category_Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public bool status { get; set; }


        //relacion con products
        public ICollection<Products> Products { get; set; } = new List<Products>();

    }
}
