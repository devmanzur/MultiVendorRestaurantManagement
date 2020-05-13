namespace Catalogue.ApiContract.Response
{
    public class OfferMinimalDto
    {
        public OfferMinimalDto(long id, string name, string imageUrl, string description)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public long Id { get; set; }
    }
}