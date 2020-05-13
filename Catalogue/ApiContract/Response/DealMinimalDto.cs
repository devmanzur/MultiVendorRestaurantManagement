namespace Catalogue.ApiContract.Response
{
    public class DealMinimalDto
    {
        public DealMinimalDto(long id, string name, string imageUrl, string description)
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