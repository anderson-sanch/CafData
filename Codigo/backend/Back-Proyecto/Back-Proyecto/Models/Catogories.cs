using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Back_Proyecto.Models
{
    public class Catogories

    {
        public Guid Category_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }

    }
}
