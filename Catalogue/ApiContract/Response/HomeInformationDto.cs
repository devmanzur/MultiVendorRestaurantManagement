using System.Collections.Generic;

namespace Catalogue.ApiContract.Response
{
    public  class HomeInformationDto
    {
        public List<CategoryMinimalDto> Categories { get; set; }
        public List<DealMinimalDto> Deals { get; set; }
        public List<RestaurantMinimalDto> Restaurants { get; set; }
    }
}