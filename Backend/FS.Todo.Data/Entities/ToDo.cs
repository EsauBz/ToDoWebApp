using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fs.Todo.Data.Entities
{
    public class ToDo
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid id { get; set; }
    }
}
