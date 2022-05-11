using ApiConciertosAWS.Models;
using ApiConciertosAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConciertosAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private RepositoryEventos repo;

        public EventosController(RepositoryEventos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Evento>> GetEventos()
        {
            return this.repo.GetEventos();
        }

        [HttpGet("{idcategoria}")]
        public ActionResult<List<Evento>> GetEventosCategoria(int idcategoria)
        {
            return this.repo.GetEventosCategoria(idcategoria);
        }

        [HttpGet("{idevento}")]
        public ActionResult<Evento> FindEvento(int idevento)
        {
            return this.repo.FindEvento(idevento);
        }

        [HttpPost]
        public ActionResult InsertEvento(Evento evento)
        {
            this.repo.InsertEvento(evento.Nombre,evento.Artista,evento.IdCategoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.repo.EliminarEvento(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult CambiarCategoria(Evento evento)
        {
            this.repo.CambiarCategoria(evento);
            return Ok();
        }
    }
}
