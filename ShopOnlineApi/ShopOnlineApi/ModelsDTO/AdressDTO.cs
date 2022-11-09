namespace ShopOnlineApi.ModelsDTO
{
    public partial class AdressDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? HouseNumber { get; set; }
        public int UserId { get; set; }


    }
}
