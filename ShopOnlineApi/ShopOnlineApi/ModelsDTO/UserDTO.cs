namespace ShopOnlineApi.ModelsDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public DateOnly? RegisterDate { get; set; }
    }
}
