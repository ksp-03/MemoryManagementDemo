using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.DAL.Models;
using TodoApp.DAL;
using TodoApp.BLL;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoAppService _todoAppService;

        public TodoController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_todoAppService.GetAllTodos());
        }

        [HttpPost("/todos")]
        public ActionResult<Todo> AddTodo([FromBody]Todo todo) {

            _todoAppService.AddTodo(todo);
            return Ok(todo);
        }
    }
}
