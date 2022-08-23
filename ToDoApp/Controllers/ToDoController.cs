using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.ValidationRules;
using ToDoApp.Entities;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {

        private readonly IToDoBusiness _toDoBusiness;

        public ToDoController(IToDoBusiness toDoBusiness)
        {
            _toDoBusiness = toDoBusiness;
        }

        public IActionResult Index()
        {
            var toDos = _toDoBusiness.GetList();
            return View(toDos);
        }


        [HttpGet]
        public IActionResult CreateToDo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateToDo(ToDo toDo)
        {
            ToDoValidator validations = new ToDoValidator();
            ValidationResult results = validations.Validate(toDo);

            if(results.IsValid)
            {
                toDo.AktifMi = false;
                toDo.OlusturmaTarihi = DateTime.Now;
                _toDoBusiness.Create(toDo);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
            
        }


        public IActionResult DeleteToDo(int id)
        {
            var delete = _toDoBusiness.GetByID(id);
            _toDoBusiness.Delete(delete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateToDo(int id)
        {
            var edit = _toDoBusiness.GetByID(id);

            return View(edit);
        }


        [HttpPost]
        public IActionResult UpdateToDo(ToDo toDo)
        {
            ToDoValidator validations = new ToDoValidator();
            ValidationResult results = validations.Validate(toDo);
            if(results.IsValid)
            {
                toDo.DegistimeTarihi = DateTime.Now;
                toDo.Bildirildi = false;
                _toDoBusiness.Update(toDo);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
           
            
        }



        public JsonResult ControlToDo()
        {

            var results= _toDoBusiness.GetList().Where(x=>x.BitisTarihi<=DateTime.Now.AddMinutes(30) && x.BitisTarihi> DateTime.Now && x.AktifMi==false && x.Bildirildi==false);

            var listTrue = new List<ToDo>();

            
            if (results != null || listTrue != null)
            {
                foreach (var item in results)
                {
                    item.Bildirildi = true;
                    listTrue.Add(item);
                }
                _toDoBusiness.Save();

                return Json(listTrue);
            }
                
            return Json("");

        }
    }
}
