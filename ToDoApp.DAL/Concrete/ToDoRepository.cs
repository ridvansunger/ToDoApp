using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DAL.Abstract;
using ToDoApp.DAL.Context;
using ToDoApp.Entities;

namespace ToDoApp.DAL.Concrete
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ProjectContext _context;

        public ToDoRepository(ProjectContext context)
        {
            _context = context;
        }

        public List<ToDo> GetList()
        {
            return _context.Todos.ToList();
        }

        public void Create(ToDo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
        }

        public void Update(ToDo todo)
        {
            _context.Update(todo);
            _context.SaveChanges();
        }

        public void Delete(ToDo todo)
        {
            _context.Remove(todo);
            _context.SaveChanges();
        }

        public ToDo GetByID(int id)
        {
            return _context.Todos.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
