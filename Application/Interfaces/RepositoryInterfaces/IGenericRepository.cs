﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task Update(Guid id, T entity);
        Task Delete(Guid id);
        Task FindBy(Guid id);
    }
}
