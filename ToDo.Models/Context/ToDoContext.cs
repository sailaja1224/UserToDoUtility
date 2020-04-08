using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ToDo.Models.Entities;

namespace ToDo.Models.Context
{
    public class ToDoContext : DbContext
    {
        public DbSet<UserToDo> UserToDos { get; set; }

        public ToDoContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(ToDoContext).Assembly);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}