using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri.Interface
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task DeleteById(int id);
    }
}
