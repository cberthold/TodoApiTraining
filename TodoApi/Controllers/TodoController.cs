using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Commands;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext context;

        public TodoController(TodoContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            var command = new GetAllTodoItems();
            var service = new GetAllTodoItemsService(context);
            var items = service.Handle(command);
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(Guid id)
        {
            var command = new GetTodoItem
            {
                Id = id,
            };

            var service = new GetTodoItemService(context);
            var item = service.Handle(command);
            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        public Guid Post([FromBody] TodoItem value)
        {
            var command = new CreateTodoItem
            {
                Description = value.Description,
                IsDone = value.IsDone,
            };

            var service = new CreateTodoItemService(context);
            var id = service.Handle(command);
            return id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] TodoItem value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
