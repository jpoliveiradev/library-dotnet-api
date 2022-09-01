using FluentValidation;
using Library.API.V2.Dtos.AluguelUpdateDto;

namespace Library.API.Validators.AluguelValidations
{
    public class AluguelUpdateValidator : AbstractValidator<AluguelUpdateDto>
    {
        public AluguelUpdateValidator()
        {
            RuleFor(a => a.LivroId)
                .NotEmpty().WithMessage("Informe o livro do aluguel")
                .GreaterThanOrEqualTo(1).WithMessage("Informe o livro do aluguel");
            RuleFor(a => a.ClienteId)
                .NotEmpty().WithMessage("Informe o cliente do aluguel")
                .GreaterThanOrEqualTo(1).WithMessage("Informe o cliente do aluguel");
            RuleFor(a => a.DataAluguel)
                .NotEmpty().WithMessage("Informe a data de aluguel");
            RuleFor(a => a.DataAluguel)
                .NotNull().WithMessage("Informe a data de previsão de entrega");
            RuleFor(a => a.DataDevolucao)
                .NotEmpty().WithMessage("Informe a data de devolução de entrega");
        }
    }
}
