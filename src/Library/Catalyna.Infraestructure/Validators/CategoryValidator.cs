using Catalyna.Core.DTOS;
using FluentValidation;

namespace Catalyna.Infraestructure.Validators
{
    public class CategoryValidator: AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Title)
               .NotNull()
               .Length(5, 50); //Longitud Minimo 20 a 500
        }
    }
}
