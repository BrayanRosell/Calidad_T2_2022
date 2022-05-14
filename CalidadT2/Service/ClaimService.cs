using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Service
{
    public interface IClaimService
    {
        void setHttpContext(HttpContext httpContext);
        Usuario GetLoggedUsername();
        List<Biblioteca> ObtenerDatosBiblioteca();
        Comentario AddComentario(Comentario comentario);
        void AddLibro(Biblioteca biblioteca);
        Biblioteca marcarComoLeyendo(int libroId, Usuario user);
        void GuardarEnDB();
    }
    public class ClaimService : IClaimService
    {
        private HttpContext httpContext;
        private readonly AppBibliotecaContext app;
        public ClaimService(AppBibliotecaContext app)
        {
            this.app = app;
        }
        public void setHttpContext(HttpContext httpContext)
        {
            this.httpContext = httpContext;

        }

        public Usuario GetLoggedUsername()
        {
            var claim = httpContext.User.Claims.FirstOrDefault();
            var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
        public Comentario AddComentario(Comentario comentario)
        {

            app.Comentarios.Add(comentario);
            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();
            return comentario;
        }
        //Biblioteca
        public List<Biblioteca> ObtenerDatosBiblioteca()
        {

            return app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == 1)
                .ToList();
        }

        public void AddLibro(Biblioteca biblioteca)
        {
            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();
        }

        public Biblioteca marcarComoLeyendo(int libroId, Usuario user)
        {
            var libro = app.Bibliotecas.Where(o => o.LibroId == libroId && o.UsuarioId == user.Id).FirstOrDefault();
            libro.Estado = ESTADO.LEYENDO;
            return libro;
        }

        public void GuardarEnDB()
        {
            app.SaveChanges();
        }
    }
}
