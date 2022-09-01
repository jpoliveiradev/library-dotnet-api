using FluentValidation;
using Library.API.V2.Dtos.ClienteDto;

namespace Library.API.Validators.ClienteValidations
{
    public class ClienteValidator : AbstractValidator<ClienteDto>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.NomeUsuario)
                .NotEmpty().WithMessage("Informe o nome do Cliente!")
               .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Informe o endereço do Cliente!")
                .MinimumLength(5).WithMessage("Mínimo 5 caracteres!")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres!");
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Informe a cidade do Cliente!")
                .MinimumLength(5).WithMessage("Mínimo 5 caracteres!")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Informe o email do Cliente!")
                .EmailAddress().WithMessage("Informe um email válido");
        }
    }
}
