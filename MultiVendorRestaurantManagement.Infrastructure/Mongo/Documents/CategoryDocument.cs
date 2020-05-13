using System.Collections.Generic;
using System.Linq;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class CategoryDocument : BaseDocument
    {
        public IReadOnlyList<long> SimilarCategories;

        public CategoryDocument(long categoryId, string imageUrl, string name, string nameEng, string categorize)
        {
            CategoryId = categoryId;
            ImageUrl = imageUrl;
            Name = name;
            NameEng = nameEng;
            Categorize = categorize;
            SimilarCategories = new List<long>();
        }

        public long CategoryId { get; protected set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Categorize { get; protected set; }

        public bool HasSimilarCategories()
        {
            return SimilarCategories.Any();
        }

        public void AddSimilarCategory(long categoryId)
        {
            var items = SimilarCategories.ToList();
            items.Add(categoryId);
            SimilarCategories = items;
        }
    }
}