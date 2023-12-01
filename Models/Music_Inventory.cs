namespace Assignment5_Voglewede_Woods.Models
{
    public class Music_Inventory
    {
        public required int Id { get; set; }
        public required string AlbumName { get; set; }
        public required string Genre { get; set; }
        public required string Performer { get; set; }
        public required string Year { get; set; }
        public required string Type { get; set; }
        public required decimal Price { get; set; }

    }
}
