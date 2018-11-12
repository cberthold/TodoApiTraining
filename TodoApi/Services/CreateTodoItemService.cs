using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Commands;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class CreateTodoItemService
    {
        private readonly TodoContext context;

        public CreateTodoItemService(TodoContext context)
        {
            this.context = context;
        }

        public Guid Handle(CreateTodoItem command)
        {
            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Description = command.Description,
                IsDone = command.IsDone,
            };

            context.TodoItems.Add(todoItem);
            context.SaveChanges();

            return todoItem.Id;
        }
    }
}
