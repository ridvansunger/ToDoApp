using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Abstract;
using ToDoApp.DAL.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.Business.Concrete
{
    public class ToDoBusiness : IToDoBusiness
    {

        IToDoRepository _todoRepository;


        public ToDoBusiness(IToDoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void Create(ToDo todo)
        {
            _todoRepository.Create(todo);
        }

        public void Delete(ToDo todo)
        {
            _todoRepository.Delete(todo);
            
        }

        public ToDo GetByID(int id)
        {
            return _todoRepository.GetByID(id);
        }

        public List<ToDo> GetList()
        {
            return _todoRepository.GetList();
        }

        public void Save()
        {
            _todoRepository.Save();
        }

        public void Update(ToDo todo)
        {
            _todoRepository.Update(todo);
        }
    }
}
