using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoMVC.Context;
using ProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {

        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context){
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contato.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if(ModelState.IsValid){
                _context.Contato.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contato.Find(id);

            if(contato == null)
                return NotFound();

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _context.Contato.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contato.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contato.Find(id);
            
            if(contato == null)
                return NotFound();

            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contato.Find(id);
            
            if(contato == null)
                return NotFound();

            return View(contato);
        }
        

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.Contato.Find(contato.Id);

            _context.Contato.Remove(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
     }
}