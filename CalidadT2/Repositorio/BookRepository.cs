using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface IBookRepository
    {
        List<Libro> ObtenerLibrosConAutores();

        object ObtenerFirst(int id);

    }
    public class BookRepository : IBookRepository
    {
        private AppBibliotecaContext app;
        public BookRepository(AppBibliotecaContext app)
        {
            this.app = app;
        }
        public List<Libro> ObtenerLibrosConAutores()
        {
            return app.Libros.Include(o => o.Autor).ToList();

        }
        public object ObtenerFirst(int id)
        {

            return app.Libros
                 .Include("Autor")
                 .Include("Comentarios.Usuario")
                 .Where(o => o.Id == id)
                 .FirstOrDefault();
        }

    }
}
