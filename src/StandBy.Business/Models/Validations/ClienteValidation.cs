using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StandBy.Business.Models.Validations
{
    class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.RAZAO_SOCIAL).MinimumLength(6).MaximumLength(200).NotNull().NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido");

            RuleFor(c => c.CNPJ).Length(14).NotNull().NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido");

            RuleFor(c => c.DATA_FUNDACAO).NotNull().NotEmpty().LessThan(DateTime.Now).WithMessage("A data não pode ser nula, ou uma data futura");

            RuleFor(c => c.CAPITAL).GreaterThan(0).NotNull().NotEmpty().WithMessage("Capital precisa ser maior que 0 e não ser vazio");

           
        }

    }
}
