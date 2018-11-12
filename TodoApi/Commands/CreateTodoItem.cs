using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Commands
{
    public class CreateTodoItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
