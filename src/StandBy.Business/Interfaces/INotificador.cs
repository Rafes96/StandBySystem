using StandBy.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace StandBy.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> GetNotificacaos();
        void Handle(Notificacao notificacao);
    }
}
