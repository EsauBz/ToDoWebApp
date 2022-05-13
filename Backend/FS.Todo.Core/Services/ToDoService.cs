using Fs.Todo.Core.Interfaces;
using Fs.Todo.Core.Models;
using Fs.Todo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fs.Todo.Core.Services
{
    public class ToDoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public ToDoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<ToDoModel> CreateTodoAsync(ToDoModel todoModel)
        {
            if (todoModel is null)
            {
                throw new ArgumentNullException(nameof(todoModel));
            }
            var todoEntity = new Data.Entities.ToDo
            {
                Description = todoModel.Description,
                IsCompleted = todoModel.IsCompleted
            };
            todoEntity = await _todoRepository.AddAsync(todoEntity);
            return new ToDoModel
            {
                id = todoEntity.id,
                Description = todoEntity.Description,
                IsCompleted = todoEntity.IsCompleted
            };
        }

        public async Task DeleteTodoAsync(Guid todoId)
        {
            await _todoRepository.RemoveAsync(todoId);
        }

        public async Task<ToDoModel> GetTodoAsync(Guid todoId)
        {
            var todoEntity = await _todoRepository.FindAsync(todoId);
            if(todoEntity is null)
            {
                return null;
            }
            return new ToDoModel
            {
                id = todoEntity.id,
                Description = todoEntity.Description,
                IsCompleted = todoEntity.IsCompleted
            };
        }

        public async Task<List<ToDoModel>> GetTodosAsync()
        {
            IQueryable<Data.Entities.ToDo> query = _todoRepository.Get();
            return await query.Select(todo => new ToDoModel { 
                id = todo.id,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            }).ToListAsync();
        }

        public async Task<ToDoModel> UpdateTodoAsync(ToDoModel todoModel)
        {
            var todoEntity = new Data.Entities.ToDo
            {
                Description = todoModel.Description,
                id = todoModel.id,
                IsCompleted = todoModel.IsCompleted
            };
            todoEntity = await _todoRepository.UpdateAsync(todoEntity);

            return new ToDoModel
            {
                id = todoEntity.id,
                Description = todoEntity.Description,
                IsCompleted = todoEntity.IsCompleted
            };
        
        }
    }
}
