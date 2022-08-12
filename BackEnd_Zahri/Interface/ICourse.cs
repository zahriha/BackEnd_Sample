using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri.Interface
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByName(string name);

    }
}
