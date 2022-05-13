using Fs.Todo.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fs.Todo.Core.Interfaces
{
    public interface ITodoService
    {
        public Task<ToDoModel> CreateTodoAsync(ToDoModel todoModel);
        public Task<ToDoModel> UpdateTodoAsync(ToDoModel todoModel);
        public Task<ToDoModel> GetTodoAsync(Guid todoId);
        public Task DeleteTodoAsync(Guid todoId);
        public Task<List<ToDoModel>> GetTodosAsync();
    }
}
