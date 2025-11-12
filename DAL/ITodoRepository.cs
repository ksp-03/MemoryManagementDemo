using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{   internal class ITodoRepository
    {
        Todo[] GetAll();
        void Save();

        Todo GetById(int id);
    }
}
