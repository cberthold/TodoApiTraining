using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly DeleteTodoItemService delService;
        private readonly GetAllTodoItemsService getAllservice;
        private readonly UpdateTodoItemService updateService;

        public TodoController(TodoContext context, 
                                GetAllTodoItemsService getAllservice, 
                                UpdateTodoItemService servicePut,
                                DeleteTodoItemService delService )
        
        {
            this.context = context;
            this.delService = delService;
            this.getAllservice = getAllservice;
            this.updateService = servicePut;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            var command = new GetAllTodoItems();
            var items = getAllservice.Handle(command);
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
            var command = new UpdateTodoItem
            {
                Id = id,
                Description = value.Description,
                IsDone = value.IsDone,
            };

            updateService.Handle(command);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var command = new DeleteTodoItem()
            {
                Id = id,
            };
           
            delService.Handle(command);
        }
    }
}
