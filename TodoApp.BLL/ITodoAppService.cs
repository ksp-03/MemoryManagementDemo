using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL;
using TodoApp.DAL.Models;

namespace TodoApp.BLL
{
    public interface ITodoAppService
    {
        IEnumerable<Todo> GetAllTodos();
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(int id);

    }

    public class TodoAppService : ITodoAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTodo(Todo todo)
        {
            _unitOfWork.Todos.Add(todo);
        }

        public void DeleteTodo(int id)
        {
            _unitOfWork.Todos.Delete(id);
        }

        public IEnumerable<Todo> GetAllTodos()
        {
           return _unitOfWork.Todos.GetAll();
        }

        public void UpdateTodo(Todo todo)
        {
            _unitOfWork.Todos.Update(todo);
        }
    }
}
