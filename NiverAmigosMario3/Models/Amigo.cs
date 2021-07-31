using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NiverAmigosMario3.Models
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }


        public static List<Amigo> Amigos { get; set; } = new List<Amigo>();

        public List<Amigo> NiverDia { get; set; } = new List<Amigo>();

        public List<Amigo> NiverOrdenado { get; set; } = new List<Amigo>();

    }
}
