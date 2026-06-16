namespace LibraryManagementSystem.Models
{
    public class BookItem
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public bool IsAvailable { get; set; }
    }
}
