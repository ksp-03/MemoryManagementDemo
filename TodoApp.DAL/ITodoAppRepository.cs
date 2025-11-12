using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Models;

namespace TodoApp.DAL
{
    public interface ITodoAppRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        void Add(Todo todo);
        void Update(Todo todo);
        void Delete(int id);

    }
}
