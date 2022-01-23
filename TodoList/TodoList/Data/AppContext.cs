using Microsoft.EntityFrameworkCore;
using System;
using TodoList.Models;

namespace TodoList.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Purpose> Purposes { get; set; } = null!;

        public AppContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=todolist;");
        }
    }
}
