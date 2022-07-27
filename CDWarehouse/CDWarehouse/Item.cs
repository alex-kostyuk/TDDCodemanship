namespace CDWarehouse
{
    public class Item
    {
        public Item(string artist, string title, int quantity = 0)
        {
            Artist = artist;
            Title = title;
            StockLevel = quantity;
        }

        public int StockLevel { get; internal set; }

        public string Artist { get; set; }

        public string Title { get; set; }

        public int Rating => ratingTotal / numberOfVotes;

        int numberOfVotes = 0;
        int ratingTotal = 0;

        internal void UpdateRating(int rating)
        {
            numberOfVotes++;
            ratingTotal += rating;
        }
    }
}
