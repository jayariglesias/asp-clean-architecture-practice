using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(T pbj);
    }
}
