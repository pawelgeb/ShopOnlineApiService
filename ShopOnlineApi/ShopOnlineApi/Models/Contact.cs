namespace ShopOnlineApi.ModelsSQL
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAdress { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
