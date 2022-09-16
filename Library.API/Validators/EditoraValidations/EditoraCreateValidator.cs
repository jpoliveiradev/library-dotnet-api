using FluentValidation;
using Library.API.V2.Dtos.EditoraDto;

namespace Library.API.Validators.EditoraCreateValidator {
    public class EditoraCreateValidator : AbstractValidator<EditoraCreateDto>
    {
        public EditoraCreateValidator()
        {
            RuleFor(e => e.NomeEditora)
                   .NotEmpty().WithMessage("Informe o nome da Editora!")
                   .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                   .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(e => e.Cidade)
                   .NotEmpty().WithMessage("Informe a cidade da Editora!")
                   .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                   .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
        }
    }
}
