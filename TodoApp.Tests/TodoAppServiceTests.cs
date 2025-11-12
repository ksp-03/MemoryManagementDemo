using Moq;
using Xunit;
using TodoApp.BLL;
using TodoApp.DAL;
using TodoApp.DAL.Models;
using System.Collections.Generic;

namespace TodoApp.Tests.Services
{
    public class TodoAppServiceTests
    {
        [Fact]
        public void AddTodo_Should_Call_Repository_Add()
        {
            // Arrange
            var mockRepo = new Mock<ITodoAppRepository>();
            var service = new TodoAppService(mockRepo.Object);
            var newTodo = new Todo { Id = 1, Title = "Test Todo" };

            // Act
            service.AddTodo(newTodo);

            // Assert
            mockRepo.Verify(r => r.Add(newTodo), Times.Once);
        }
    }
}
