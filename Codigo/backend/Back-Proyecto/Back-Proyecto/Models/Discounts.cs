namespace Back_Proyecto.Models
{
    public class Discounts

    {
        public Guid Discount_Id { get; set; }
        public Guid Product_Id { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool active { get; set; }
        public string Description { get; set; }

    }
}
