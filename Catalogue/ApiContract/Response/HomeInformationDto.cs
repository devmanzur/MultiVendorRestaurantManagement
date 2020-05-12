using System.Collections.Generic;

namespace Catalogue.ApiContract.Response
{
    public abstract class HomeInformationDto
    {
        public List<CategoryMinimalDto> Categories { get; set; }
        public List<List<OfferMinimalDto>> OfferGroups { get; set; }
        public List<RestaurantMinimalDto> Restaurants { get; set; }
        public List<FoodMinimalDto> Foods { get; set; }
        
    }
}