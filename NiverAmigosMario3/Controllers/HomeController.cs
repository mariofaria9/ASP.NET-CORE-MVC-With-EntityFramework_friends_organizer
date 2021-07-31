using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NiverAmigosMario3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NiverAmigosMario3.Data;
using System.Data.Entity.Core.Objects;


namespace NiverAmigosMario3.Controllers
{
    public class HomeController : Controller
    {
        public BancoDeDados BancoDeDados { get; }

        public HomeController(BancoDeDados bancoDeDados)
        {
            BancoDeDados = bancoDeDados;
        }

        public IActionResult Index()
        {
            var model = new Casamodel();
            
            model.amigosDoDia = BancoDeDados.Amigos.Where(amigo => (amigo.DataNascimento.Day == DateTime.Today.Day) && (amigo.DataNascimento.Month == DateTime.Today.Month)).ToList();

            model.amigosOrdenados = BancoDeDados.Amigos.OrderBy(amigo => amigo.DataNascimento.Month).ThenBy(amigo => amigo.DataNascimento.Day).ToList();

            //var amigosOrdenados0 = BancoDeDados.Amigos.Where(amigo => (amigo.DataNascimento.Day > DateTime.Today.Day) && (amigo.DataNascimento.Month > DateTime.Today.Month)).ToList();

            //var amigosOrdenados1 = BancoDeDados.Amigos.Where(amigo => (amigo.DataNascimento.Day < DateTime.Today.Day) && (amigo.DataNascimento.Month < DateTime.Today.Month)).ToList();

            //model.amigosOrdenados = BancoDeDados.Amigos.OrderBy(amigo => amigosOrdenados0.Concat(amigosOrdenados1).ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
