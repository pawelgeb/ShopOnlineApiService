namespace ShopOnlineApi.ModelsSQL
{
    public partial class Adress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? HouseNumber { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
