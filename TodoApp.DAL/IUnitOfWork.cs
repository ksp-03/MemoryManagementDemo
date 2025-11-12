using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DAL
{
    public interface IUnitOfWork
    {
        public ITodoAppRepository Todos { get; }

        public void Save();
    }

    public class UnitofWork : IUnitOfWork
    {
       public ITodoAppRepository Todos { get; private set; }

        public UnitofWork()
        {
            Todos = new InMemoryTodoRepository();
        }

        void IUnitOfWork.Save()
        {
           //Do nothing for in-memory repo
        }
    }
}
