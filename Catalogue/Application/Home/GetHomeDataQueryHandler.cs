using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;
using MediatR;

namespace Catalogue.Application.Home
{
    public class GetHomeDataQueryHandler : IQueryHandler<GetHomeDataQuery, Result<HomeInformationDto>>
    {
        public Task<Result<HomeInformationDto>> Handle(GetHomeDataQuery request, CancellationToken cancellationToken)
        {
            //need mongodb document setup
            throw new System.NotImplementedException();
        }
    }
}