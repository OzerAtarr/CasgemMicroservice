namespace CasgemMicroservice.Discount.Dtos
{
    public class UpdateDiscountDto
    {
        public int DiscountCouponID { get; set; }
        public string UserID { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
