﻿using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MessengerBotAPI.Application.Order.PlaceOrder
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Result<object>>
    {
        private PlaceOrderCommand _reuquest;

        public async Task<Result<object>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            //make another call to dialogflow to request users address
            _reuquest = request;
            return Result.Ok("order could not be placed");
        }
    }
}