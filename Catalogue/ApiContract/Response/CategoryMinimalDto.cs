namespace Catalogue.ApiContract.Response
{
    public class CategoryMinimalDto
    {
        public CategoryMinimalDto(long id, string name, string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public string ImageUrl { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}