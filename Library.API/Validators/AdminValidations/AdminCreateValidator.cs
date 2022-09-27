using FluentValidation;
using Library.API.V2.Dtos.AdminCreateDto;

namespace Library.API.Validators.AdminValidations {
    public class AdminCreateValidator : AbstractValidator<AdminCreateDto> {
        public AdminCreateValidator() {
            RuleFor(c => c.NomeAdmin)
                .NotEmpty().WithMessage("Informe o nome do Admin!")
               .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("Informe o email do Admin!")
                     .EmailAddress().WithMessage("Informe um email válido");
            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Informe o endereço do Admin!")
                .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres!");
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Informe o username do Admin!")
                .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres!");
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Informe a senha do Admin!")
                .MinimumLength(3).WithMessage("Mínimo 3 caracteres!")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres!");

        }
    }
}
