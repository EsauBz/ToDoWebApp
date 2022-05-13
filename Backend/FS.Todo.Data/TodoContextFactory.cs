using Fs.Todo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace FS.Todo.Data
{
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionBuilder.UseSqlite("Data Source=todos.db");

            return new TodoContext(optionBuilder.Options);
        }
    }
}
