using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Home
{
    public class GetHomeDataQuery : IQuery<Result<HomeInformationDto>>
    {
    }
}