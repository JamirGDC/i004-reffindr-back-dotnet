﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public IUsersRepository UsersRepository { get; }

    public IAuthRepository AuthRepository { get; }

    public UnitOfWork
        (
            ApplicationDbContext dbContext,
            IUsersRepository usersRepository,
            IAuthRepository authRepository
        )
    {
        _dbContext = dbContext;
        UsersRepository = usersRepository;
        AuthRepository = authRepository;
    }
    public async Task<int> Complete(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
    {
        return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }
}