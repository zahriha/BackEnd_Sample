using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri.Interface
{
    public interface IStudent : ICrud<Student>
    {
        Task<IEnumerable<Student>> GetByName(string name);

    }
}
