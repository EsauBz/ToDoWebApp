using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fs.Todo.Api.Models
{
    public class UpdatedTodoModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
