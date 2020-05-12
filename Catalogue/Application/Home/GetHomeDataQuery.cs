using System.Collections.Generic;
using Catalogue.ApiContract;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;
using MediatR;

namespace Catalogue.Application.Home
{
    public class GetHomeDataQuery : IQuery<Result<HomeInformationDto>>
    {
    }
}