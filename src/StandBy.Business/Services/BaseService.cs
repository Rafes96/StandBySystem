using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using StandBy.Business.Interfaces;
using StandBy.Business.Models;
using StandBy.Business.Notifications;

namespace StandBy.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificacao(ValidationResult validationResult)
        {
            foreach (var errors in validationResult.Errors)
            {
                Notificacao(errors.ErrorMessage);
            }
        }

        protected void Notificacao(string msg)
        {
            _notificador.Handle(new Notificacao(msg));
        }

        protected bool ValidationExecute<Tvalidation, Tentidade>(Tvalidation validacao, Tentidade entidade) where Tvalidation : AbstractValidator<Tentidade>
            where Tentidade : Cliente
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid)
            {
                return true;
            }
            
            Notificacao(validator);

            return false;   
        }
    }
}
