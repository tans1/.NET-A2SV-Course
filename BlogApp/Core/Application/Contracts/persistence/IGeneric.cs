using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGeneric<T>
    {
        public Task<T?> Create(T entity);
        public Task<T?> Delete(int id);
    }
}
