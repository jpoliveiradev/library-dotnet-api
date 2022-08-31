using FluentValidation;
using Library.API.Models;

namespace Library.API.Validators {
    public class EditoraValidator : AbstractValidator<Editoras> {
        public EditoraValidator() {
            RuleFor(e => e.NomeEditora)
                   .NotEmpty().WithMessage("Informe o nome da Editora!")
                   .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                   .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(e => e.Cidade)
                   .NotEmpty().WithMessage("Informe a cidade da Editora!")
                   .MinimumLength(5).WithMessage("Mínimo 3 caracteres!")
                   .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
        }
    }
}
