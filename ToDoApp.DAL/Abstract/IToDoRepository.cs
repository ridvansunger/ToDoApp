using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities;

namespace ToDoApp.DAL.Abstract
{
    public interface IToDoRepository
    {
        void Create(ToDo todo);
        void Delete(ToDo todo);
        void Update(ToDo todo);
        List<ToDo> GetList();
        ToDo GetByID(int id);
        void Save();
    }
}
