using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Catalogue.Common.Utils;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class CategoryDocument : BaseDocument
    {
        public IReadOnlyList<long> SimilarCategories;

        // public CategoryDocument(long categoryId, string imageUrl, string name, string nameEng, string categorize)
        // {
        //     CategoryId = categoryId;
        //     ImageUrl = imageUrl;
        //     Name = name;
        //     NameEng = nameEng;
        //     Categorize = categorize;
        //     SimilarCategories = new List<long>();
        // }

        public long CategoryId { get; protected set; }
        public string ImageUrl { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
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

        public static Expression<Func<CategoryDocument, object>> GetOrderBy(string orderBy)
        {
            if (orderBy.HasNoValue()) return x => x.Id;
            return orderBy.ToLowerInvariant() switch
            {
                "name" => x => x.Name,
                "id" => x => x.CategoryId,
                _ => x => x.Id
            };
        }
    }
}