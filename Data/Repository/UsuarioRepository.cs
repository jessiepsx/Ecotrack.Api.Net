using Ecotrack.Api.Net.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Ecotrack.Net.Models;
using Ecotrack.Api.Net.Data.Repository;

namespace EcoTrack.API.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EcotrackContext _context;

        public UsuarioRepository(EcotrackContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public IEnumerable<Usuario> GetAll(int page, int size)
        {
            return _context.Usuarios
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email == email);
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
