namespace catchme.bg.Models
{
    public class Ethnicity : IProfileItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
}