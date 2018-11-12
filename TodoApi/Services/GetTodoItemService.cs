using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Commands;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class GetTodoItemService
    {
        private readonly TodoContext context;

        public GetTodoItemService(TodoContext context)
        {
            this.context = context;
        }

        public TodoItem Handle(GetTodoItem command)
        {
            var id = command.Id;

            var item = (from i in context.TodoItems
                        where i.Id == id
                        select i).FirstOrDefault();

            return item;
        }
    }
}
