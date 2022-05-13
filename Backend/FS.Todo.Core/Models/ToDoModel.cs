using System;

namespace Fs.Todo.Core.Models
{
    public class ToDoModel
    {
        public Guid id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
