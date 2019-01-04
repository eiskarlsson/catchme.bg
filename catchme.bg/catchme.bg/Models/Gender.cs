namespace catchme.bg.Models
{
    public class Gender : IProfileItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
}