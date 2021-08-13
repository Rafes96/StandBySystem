
using StandBy.Business.Interfaces;
using System;
using System.Collections.Generic;
using StandBy.Business.Notifications;
using System.Text;
using System.Linq;

namespace StandBy.Business.Notifications
{
    
    public class Notificador : INotificador
    {


        private List<Notificacao> _listaNotificacao;

        public Notificador()
        {
            _listaNotificacao = new List<Notificacao>();
        }

        public List<Notificacao> GetNotificacaos()
        {
            return _listaNotificacao;
        }

        public void Handle(Notificacao notificacao)
        {
            _listaNotificacao.Add(notificacao);  
        }

        public bool TemNotificacao()
        {
            return _listaNotificacao.Any();
        }
    }
}
