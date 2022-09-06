using FluentValidation;
using Library.API.V2.Dtos.LivroCreateDto;

namespace Library.API.Validators.LivroValidations
{
    public class LivroCreateValidator : AbstractValidator<LivroCreateDto>
    {
        public LivroCreateValidator()
        {
            RuleFor(l => l.NomeLivro)
               .NotEmpty().WithMessage("Informe o nome do Livro!")
              .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
               .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(l => l.EditoraId)
                .NotNull().WithMessage("Informe a editora do Livro!")
                .NotEmpty().WithMessage("Informe a editora do Livro!")
                .GreaterThanOrEqualTo(1).WithMessage("ErroID");
            RuleFor(l => l.Autor)
                .NotEmpty().WithMessage("Informe o Autor do Livro!")
                .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(l => l.Lancamento)
                .NotEmpty().WithMessage("Informe a data do lancamento do Livro!");
            RuleFor(l => l.Quantidade)
                .NotNull().WithMessage("Informe a quantidade do Livro!")
                .GreaterThanOrEqualTo(1).WithMessage("Quantidade do Livro minimo deve ser 1!");
        }
    }
}
