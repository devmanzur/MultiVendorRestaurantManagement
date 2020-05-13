using System.Collections.Generic;

namespace Catalogue.ApiContract.Response
{
    public  class HomeInformationDto
    {
        public List<CategoryMinimalDto> Categories { get; set; }
        public List<OfferMinimalDto> Offers { get; set; }
        public List<RestaurantMinimalDto> Restaurants { get; set; }
        public List<FoodMinimalDto> Foods { get; set; }
        
    }
}