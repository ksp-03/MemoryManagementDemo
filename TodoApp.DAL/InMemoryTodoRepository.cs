using TodoApp.DAL.Models;

namespace TodoApp.DAL
{
    public class InMemoryTodos
    {
        public static List<Todo> Todos = new List<Todo>()
        {
            new Todo { Id = 1, Title = "12", IsCompleted = false },
            new Todo { Id = 2, Title = "14", IsCompleted = false }
        };
    }
  
    public class InMemoryTodoRepository : ITodoAppRepository
    {

        public IEnumerable<Todo> GetAll() => InMemoryTodos.Todos;

        public Todo GetById(int id) => InMemoryTodos.Todos.FirstOrDefault(t => t.Id == id);

        public void Add(Todo todo)
        {
            todo.Id = InMemoryTodos.Todos.Max(t => t.Id) + 1;
            InMemoryTodos.Todos.Add(todo);
        }

        public void Update(Todo todo)
        {
            var existing = InMemoryTodos.Todos.FirstOrDefault(t => t.Id == todo.Id);
            if (existing != null)
            {
                existing.Title = todo.Title;
                existing.IsCompleted = todo.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var todo = InMemoryTodos.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
                InMemoryTodos.Todos.Remove(todo);
        }
    }
}
