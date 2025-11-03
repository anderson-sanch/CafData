namespace Back_Proyecto.Models
{
    public class Sale_Detail

    {
        public Guid Detail_Id { get; set; }
        public Guid Sale_Id { get; set; }
        public Guid Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_Price { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount_Applied { get; set; }

    }
}
