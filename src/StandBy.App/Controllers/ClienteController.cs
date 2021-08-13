using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBy.App.ViewModels;
using StandBy.Business.Interfaces;
using StandBy.Business.Models;
using StandBy.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandBy.App.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly ICliente _cliente;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;


        public ClienteController(ICliente cliente, IMapper mapper, IClienteService clienteService, INotificador notificador) : base(notificador)
        {
            _cliente = cliente;
            _mapper = mapper;
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _cliente.GetAll()));
        }


        public IActionResult Create()
        {

            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteService.Adicionar(cliente);


            if (!OperacaoValida()) return View(clienteViewModel);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _cliente.GetEntidadeID(id));
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CLIENTE_ID,RAZAO_SOCIAL,CNPJ,DATA_FUNDACAO,CAPITAL,STATUS_CLIENTE")] ClienteViewModel clienteViewModel)
        {
            clienteViewModel.CLIENTE_ID = id;
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = _mapper.Map<Cliente>(clienteViewModel);
                    await _clienteService.Atualizar(cliente);

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                if (!OperacaoValida()) return View(clienteViewModel);

                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _cliente.GetEntidadeID(id));

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string RazaoSocial, string Cnpj, bool? situacao)
        {

            try
            {
                if (RazaoSocial != null || Cnpj != null || situacao != null)
                {
                    var empresas = _mapper.Map<IEnumerable<ClienteViewModel>>(await _cliente.Buscar(c => c.RAZAO_SOCIAL.Contains(RazaoSocial) ||
                                     c.CNPJ.Contains(Cnpj) || c.STATUS_CLIENTE == situacao));
                    return View("Index", empresas);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
