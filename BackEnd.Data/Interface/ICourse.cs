using BackEnd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Data.Interface
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByName(string name);

    }
}
