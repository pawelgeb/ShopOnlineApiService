namespace ShopOnlineApi.ModelsDTO
{
    public partial class OrderDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateOnly? OrderDate { get; set; }
        public int? Price { get; set; }
        public int? ProductId { get; set; }

    }
}