using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Interfaces
{
    public interface IClienteService
    {
        Task Adicionar(Cliente cliente);

        Task Atualizar(Cliente cliente);

        Task Remove(int id);

       
    }
}
