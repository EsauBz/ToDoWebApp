using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fs.Todo.Api.Models
{
    public class CreateTodoModel
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
