using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities;

namespace ToDoApp.Business.ValidationRules
{
    public class ToDoValidator:AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("Görev adı boş geçilemez");
            RuleFor(x => x.Aciklama).NotEmpty().WithMessage("Açıkma boş geçilemez");
            RuleFor(x => x.BitisTarihi).NotEmpty().WithMessage("Bitiş tarihi boş geçilemez");
        }
    }
}
