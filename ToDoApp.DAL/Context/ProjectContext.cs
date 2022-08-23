using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities;

namespace ToDoApp.DAL.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HGIEK1O;Database=ToDoDB;Uid=sa;pwd=123;");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ToDo> Todos { get; set; }
    }
}
