using Catalyna.Core.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Infraestructure.Validators
{
    public class ArticleValidator: AbstractValidator<ArticleDTO>
    {
        public ArticleValidator()
        {
            RuleFor(article => article.Description)
                .NotNull()
                .Length(20, 500); //Longitud Minimo 20 a 500

            RuleFor(article => article.DateCreate)
                .LessThan(DateTime.Now); // La fecha tiene que ser mayor a la fecha actual
        }
    }
}
