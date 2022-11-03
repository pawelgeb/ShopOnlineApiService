namespace ShopOnlineApi.ModelsSQL
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? RegisterDate { get; set; }
        public virtual Adress? Adress { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}
