using Fs.Todo.Data.Entities;
using Fs.Todo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fs.Todo.Data.Repositories
{
    public class ToDoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;
        public ToDoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<ToDo> AddAsync(ToDo todo)
        {
            todo.id = todo.id == Guid.Empty ? Guid.NewGuid() : todo.id;
            _todoContext.Add(todo);
            await _todoContext.SaveChangesAsync();
            return todo;
        }

        public async Task<ToDo> FindAsync(Guid id)
        {
            return await _todoContext.Todos.FindAsync(id);
        }

        public IQueryable<ToDo> Get()
        {
            return _todoContext.Todos.AsQueryable();
        }

        public async Task RemoveAsync(Guid id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);
            if(todo is not null)
            {
                _todoContext.Todos.Remove(todo);
                await _todoContext.SaveChangesAsync();
            }
        }

        public async Task<ToDo> UpdateAsync(ToDo todo)
        {
            var local = _todoContext.Todos.Local.FirstOrDefault(entity => entity.id == todo.id);
            if(local is not null)
            {
                _todoContext.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            _todoContext.Entry(todo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _todoContext.SaveChangesAsync();
            return todo;
        }
    }
}
