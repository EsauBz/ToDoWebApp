using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fs.Todo.Data.Interfaces
{
    public interface ITodoRepository
    {
        public Task<Entities.ToDo> FindAsync(Guid id);
        public Task<Entities.ToDo> UpdateAsync(Entities.ToDo todo);
        public Task<Entities.ToDo> AddAsync(Entities.ToDo todo);
        public Task RemoveAsync(Guid id);
        public IQueryable<Entities.ToDo> Get();
    }
}
