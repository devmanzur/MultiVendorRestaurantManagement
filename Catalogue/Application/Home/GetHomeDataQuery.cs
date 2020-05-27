using Catalogue.ApiContract.Response;
using Catalogue.Application.Base;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Home
{
    public class GetHomeDataQuery : IQuery<Result<HomeInformationDto>>
    {
    }
}