using Microsoft.EntityFrameworkCore;
using MVC_ToDoList.Models;

namespace MVC_ToDoList.Context
{
    public class MVCTodoListContext : DbContext
    {
        public MVCTodoListContext(DbContextOptions<MVCTodoListContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<ListModel> ListModels { get; set; }
    }
}
