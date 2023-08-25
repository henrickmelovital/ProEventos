using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento =  new Evento[]{
            new Evento() {
            EventoId = 1,
            Tema = "Angular 11 e .NET 5",
            Local = "São Paulo",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            ImagemURL = "foto.png"
            },
            new Evento() {
            EventoId = 2,
            Tema = "Angular 12 e .NET 6",
            Local = "São Paulo",
            Lote = "2º Lote",
            QtdPessoas = 330,
            DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            ImagemURL = "foto.png"
            },
        };

        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(E => E.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com Id = {id}";
        }

        [HttpDelete]
        public string Delete()
        {
            return "Deleltar";
        }
    }
}
