namespace Back_Proyecto.Models
{
    public class Inventory_Movement

    {
        public Guid Movement_Id { get; set; }
        public Guid Product_Id { get; set; }
        public string Type_Movement { get; set; }
        public Guid Queantity { get; set; }
        public string Reason { get; set; }
        public DateTime Data_Movement { get; set; }
        public Guid User_ID { get; set; }
    }
}
