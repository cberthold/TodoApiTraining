using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Commands;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class GetAllTodoItemsService
    {
        private readonly TodoContext context;

        public GetAllTodoItemsService(TodoContext context)
        {
            this.context = context;
        }

        public IEnumerable<TodoItem> Handle(GetAllTodoItems command)
        {
            return context.TodoItems.ToArray();
        }
    }
}
