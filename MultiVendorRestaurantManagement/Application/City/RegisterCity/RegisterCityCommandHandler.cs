﻿using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.City.RegisterCity
{
    public class RegisterCityCommandHandler : ICommandHandler<RegisterCityCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCityCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterCityCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Cities.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
            if (item.HasValue()) Result.Failure("city with same name already exists");

            var city = new Domain.Cities.City(request.Name, request.NameEng, request.Code);

            await _context.Cities.AddAsync(city, cancellationToken);
            var result = await _unitOfWork.CommitAsync(cancellationToken);

            return result > 0
                ? Result.Ok("City registered successfully")
                : Result.Failure("Failed to register city");
        }
    }
}