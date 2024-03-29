﻿using System.Threading;
using System.Threading.Tasks;

namespace MultiVendorRestaurantManagement.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}