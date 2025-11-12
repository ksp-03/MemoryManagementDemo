using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Models;


namespace TodoApp.DAL
{
    public class SqlAdoTodoRepository : ITodoAppRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public SqlAdoTodoRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Add(Todo todo)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var command = new SqlCommand("AddTodo", (SqlConnection)connection);
            command.CommandType = CommandType.StoredProcedure;

            // Parameters
            command.Parameters.AddWithValue("@Title", todo.Title);
            command.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);

            // Execute the stored procedure
            command.ExecuteNonQuery();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll()
        {
            var todos = new List<Todo>();

            using var connection = _connectionFactory.CreateConnection();
            using var command = new SqlCommand("GetAllTodos", (SqlConnection)connection);
            command.CommandType = CommandType.StoredProcedure;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                todos.Add(new Todo
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    IsCompleted = Convert.ToBoolean(reader["IsCompleted"])
                });
            }

            return todos;
        }

        public Todo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Todo todo)
        {
            throw new NotImplementedException();
        }

        // We'll add Add(), Update(), Delete() later
    }
}
