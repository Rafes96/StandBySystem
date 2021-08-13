using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandBy.App.Extensions
{
    public class ValidacaoViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public ValidacaoViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.GetNotificacaos());

            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));
            return View();
        }
    }
}
