﻿using FluentValidation;
using Library.API.V2.Dtos;

namespace Library.API.Validators {
    public class AluguelValidator : AbstractValidator<AluguelDto>{
        public AluguelValidator() {
            RuleFor(a => a.LivroId)
                .NotEmpty().WithMessage("Informe o livro do aluguel")
                .GreaterThanOrEqualTo(1).WithMessage("Informe o livro do aluguel");
            RuleFor(a => a.ClienteId)
                .NotEmpty().WithMessage("Informe o cliente do aluguel")
                .GreaterThanOrEqualTo(1).WithMessage("Informe o cliente do aluguel");
            RuleFor(a => a.DataAluguel)
                .NotEmpty().WithMessage("Informe a data de aluguel");
            RuleFor(a => a.DataAluguel)
                .NotEmpty().WithMessage("Informe a data de previsão de entrega");
        }
    }
}
