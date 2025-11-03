namespace Back_Proyecto.Models
{
    public class Price_History

    {
        public Guid History_Id { get; set; }
        public Guid Product_Id { get; set; }
        public decimal Previous_Price { get; set; }
        public decimal New_Price { get; set; }
        public DateTime Change_Date { get; set; }
        public Guid User_Id { get; set; }
        public string Reason { get; set; }
    }

}
