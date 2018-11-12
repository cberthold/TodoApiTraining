using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Commands;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class UpdateTodoItemService
    {
        private readonly TodoContext context;

        public UpdateTodoItemService(TodoContext context)
        {
            this.context = context;
        }

        public void Handle(UpdateTodoItem command)
        {
            var id = command.Id;

            var item = (from i in context.TodoItems
                        where i.Id == id
                        select i).First();

            item.Description = command.Description;
            item.IsDone = command.IsDone;

            context.SaveChanges();
        }
    }
}
