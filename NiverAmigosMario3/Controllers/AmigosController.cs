using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NiverAmigosMario3.Models;
using NiverAmigosMario3.Data;

namespace NiverAmigosMario3.Controllers
{
    public class AmigosController : Controller
    {
        public AmigosController(BancoDeDados bancoDeDados)
        {
            BancoDeDados = bancoDeDados;   
        }

        private BancoDeDados BancoDeDados { get; set; }


        [HttpGet]
        public IActionResult CadastrarAmigo()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult ExecutarCadastroDeAmigo(string nome, string sobrenome, DateTime datanascimento)
        {
            Amigo amigo = new Amigo();
            amigo.Nome = nome;
            amigo.Sobrenome = sobrenome;
            amigo.DataNascimento = datanascimento;

            BancoDeDados.Amigos.Add(amigo);
            BancoDeDados.SaveChanges();
           

            return RedirectToAction("AmigoCadastrado");
        }

        

        [HttpGet]
        public IActionResult Editar(int identificador)
        {
            Amigo amigo = BancoDeDados.Amigos.First(amigo => amigo.Id == identificador);
            return View(amigo);
        }

        [HttpPost]
        public IActionResult Editar(int identificador, string nome, string sobrenome, DateTime datanascimento)
        {
            Amigo amigo = BancoDeDados.Amigos.First(amigo => amigo.Id == identificador);
            amigo.Nome = nome;
            amigo.Sobrenome = sobrenome;
            amigo.DataNascimento = datanascimento;

            BancoDeDados.Amigos.Update(amigo);
            BancoDeDados.SaveChanges();

            return RedirectToAction("ListarAmigo");
        }

        [HttpGet]
        [Route("amigos/excluir")]
        public IActionResult ExcluirGet(int identificador)
        {
            Amigo amigo = BancoDeDados.Amigos.First(amigo => amigo.Id == identificador);

            return View("excluir", amigo);
        }

        [HttpPost]
        [Route("amigos/excluir")]
        public IActionResult ExcluirPost(int identificador)
        {
            Amigo amigo = BancoDeDados.Amigos.First(amigo => amigo.Id == identificador);

            BancoDeDados.Amigos.Remove(amigo);
            BancoDeDados.SaveChanges();

            return Redirect("/amigos/listaramigo");
        }

        public IActionResult Buscar()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListarAmigo(string pesquisa)
        {
            if(pesquisa != null)
            {
                List<Amigo> amigosEncontrados = BancoDeDados.Amigos.Where(amigo => amigo.Nome == pesquisa).ToList();
                return View(amigosEncontrados);
            }

            return View(BancoDeDados.Amigos.ToList());
        }

        [HttpGet]
        public IActionResult AmigoCadastrado()
        {
            return View();
        }


       
    }

}
