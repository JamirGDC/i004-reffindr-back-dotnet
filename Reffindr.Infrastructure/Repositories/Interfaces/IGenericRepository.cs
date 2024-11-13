﻿using Reffindr.Domain.Models;
using System.Linq.Expressions;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseModel
{
    Task<List<T>> GetAll();
    //Task<List<T>> GetAllWithPagination(PaginationDto paginationDto);
    Task<T> GetById(int id);
    Task<T> Create(T model, CancellationToken cancellationToken);
    Task<T> Update(int id, T model);
    Task<T> Delete(int id);
}