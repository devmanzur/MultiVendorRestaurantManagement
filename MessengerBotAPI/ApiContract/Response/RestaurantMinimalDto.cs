namespace MessengerBotAPI.ApiContract.Response
{
    public class RestaurantMinimalDto
    {
        public RestaurantMinimalDto(long id, string name, double rating, string imageUrl, string openOrClosed)
        {
            Id = id;
            Name = name;
            Rating = rating;
            ImageUrl = imageUrl;
            OpenOrClosed = openOrClosed;
        }

        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string OpenOrClosed { get; set; }
    }
}