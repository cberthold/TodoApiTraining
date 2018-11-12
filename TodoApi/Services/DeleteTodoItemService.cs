using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Commands;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class DeleteTodoItemService
    {
        private readonly TodoContext context;

        public DeleteTodoItemService(TodoContext context)
        {
            this.context = context;
        }

        public void Handle(DeleteTodoItem command)
        {
            var id = command.Id;

            var item = (from i in context.TodoItems
                        where i.Id == id
                        select i).First();

            context.TodoItems.Remove(item);
            context.SaveChanges();
        }
    }
}
