namespace Back_Proyecto.Models
{
    public class Sales
    {
        public Guid Sale_Id { get; set; }
        public Guid User_Id { get; set; }
        public Guid Client_Id { get; set; }
        public Guid Cupon_Id { get; set; }
        public DateTime Sale_Date { get; set; }
        public decimal Total { get; set; }
        public string Payment_Method { get; set; }
        public string Status { get; set; }
        public decimal Total_Discount { get; set; }
        public decimal Type_Discount { get; set; }
    }

}
