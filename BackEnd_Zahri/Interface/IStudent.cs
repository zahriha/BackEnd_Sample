using BackEnd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Data.Interface
{
    public interface IStudent : ICrud<Student>
    {
        Task<IEnumerable<Student>> GetByName(string name);

    }
}
