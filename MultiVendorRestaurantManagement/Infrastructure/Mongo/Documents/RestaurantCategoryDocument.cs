namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class RestaurantCategoryDocument  : BaseDocument
    {
        public long CategoryId { get; private set; }
        public string ImageUrl { get; protected set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }
    }
}