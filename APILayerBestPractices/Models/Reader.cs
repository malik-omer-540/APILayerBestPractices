namespace APILayerBestPractices.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> BorrowedBookIds { get; set; } = new();
    }
}
