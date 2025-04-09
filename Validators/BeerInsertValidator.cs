using FluentValidation;
using BackendHectorDeLeon.DTOs;

namespace BackendHectorDeLeon.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(50).WithMessage("El nombre no debe superar los 50 caracteres");

            RuleFor(b => b.BrandId)
                .GreaterThan(0).WithMessage("Debe seleccionar una marca válida");

            RuleFor(b => b.Alcochol)
                .InclusiveBetween(0, 100).WithMessage("El nivel de alcohol debe estar entre 0 y 100");
        }
    }
}
