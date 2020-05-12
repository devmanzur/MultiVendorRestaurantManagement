namespace Catalogue.ApiContract.Response
{
    public class RestaurantMinimalDto
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
    }
}