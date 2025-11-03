namespace Back_Proyecto.Models
{
    public class Coupons

    {
        public Guid Coupon_Id { get; set; }
        public string Coupons_Code { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Maximmum_Use { get; set; }
        public int Time_Used { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }


}
