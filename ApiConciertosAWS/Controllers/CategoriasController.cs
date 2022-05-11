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
    public class CategoriasController : ControllerBase
    {
        private RepositoryEventos repo;

        public CategoriasController(RepositoryEventos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            return this.repo.GetCategorias();
        }
    }
}
