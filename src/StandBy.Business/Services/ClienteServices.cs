using StandBy.Business.Interfaces;
using StandBy.Business.Models;
using StandBy.Business.Models.Validations;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Services
{
    public class ClienteServices : BaseService, IClienteService
    {

        private readonly ICliente _clienterepository;

        public ClienteServices(ICliente clienterepository, INotificador notificador) : base(notificador)
        {
            _clienterepository = clienterepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            //validar o estado estado da entidade
            if (!ValidationExecute(new ClienteValidation(), cliente)) return;
            //validar se não existe cliente com o mesmo cnpj

            if (_clienterepository.Buscar(c => c.CNPJ == cliente.CNPJ).Result.Any())
            {
                Notificacao("CNPJ já cadastrado");
                return ;
            }
            //classificar o cliente entre A B e C
            cliente.SetClassificao();
            //Validar o tempo de fundação do cliente menos de um ano Campo Quarentena igual a true
            cliente.SetQuarenenta();
           
            
            await _clienterepository.Adicionar(cliente);

        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ValidationExecute(new ClienteValidation(), cliente)) return;

            cliente.SetClassificao();
            await _clienterepository.Atualizar(cliente);
        
        }

        public async Task Remove(Cliente cliente)
        {
            await _clienterepository.Remove(cliente);
        }
    }
}
