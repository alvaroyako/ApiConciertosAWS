using ApiConciertosAWS.Data;
using ApiConciertosAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConciertosAWS.Repositories
{
    public class RepositoryEventos
    {
        private EventosContext context;

        public RepositoryEventos(EventosContext context)
        {
            this.context = context;
        }

        public List<Evento> GetEventos()
        {
            return this.context.Eventos.ToList();
        }

        public List<Categoria> GetCategorias()
        {
            return this.context.Categorias.ToList();
        }

        public List<Evento> GetEventosCategoria(int idcategoria)
        {
            var consulta = from datos in this.context.Eventos
                           where datos.IdCategoria == idcategoria
                           select datos;
            return consulta.ToList();
        }

        public Evento FindEvento(int id)
        {
            return this.context.Eventos.SingleOrDefault(x => x.IdEvento == id);
        }

        private int GetMaxIdEvento()
        {
            if (this.context.Eventos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Eventos.Max(x => x.IdEvento) + 1;
            }
        }

        public void InsertEvento(string nombre, string artista, int idcategoria)
        {
            Evento evento = new Evento
            {
                IdEvento = this.GetMaxIdEvento(),
                Nombre = nombre,
                Artista = artista,
                IdCategoria = idcategoria
            };
            this.context.Eventos.Add(evento);
            this.context.SaveChanges();
        }

        public void EliminarEvento(int id)
        {
            Evento evento = this.FindEvento(id);
            this.context.Eventos.Remove(evento);
            this.context.SaveChanges();
        }

        public void CambiarCategoria(Evento evento)
        {
            Evento ev = this.FindEvento(evento.IdEvento);
            ev.IdEvento = evento.IdEvento;
            ev.Nombre = evento.Nombre;
            ev.Artista = evento.Artista;
            ev.IdCategoria = evento.IdCategoria;
            this.context.SaveChanges();
        }
    }
}
