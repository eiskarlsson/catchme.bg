namespace catchme.bg.Models
{
    public class Weight : IProfileItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
}