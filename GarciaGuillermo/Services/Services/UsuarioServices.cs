using GarciaGuillermo.Context;
using GarciaGuillermo.Models.Domain;
using GarciaGuillermo.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace GarciaGuillermo.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context) {
            _context = context;
        }

        List<Usuario> IUsuarioServices.ObtenerUsuario() {
            try
            {
                List<Usuario> Result = _context.Usuarios.Include(x => x.Rol).ToList();
                return Result;
            }
            catch (Exception ex) 
            {

                throw new Exception("Sucedio un error" + ex.Message );
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            try
            {
                Usuario result = _context.Usuarios.Find(id);
                //Usuario Result = _context.Usuarios.Include(x => x.Rol).FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public bool CrearUsuario(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario ()
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    IdRol = 1
                };

                _context.Usuarios.Add(usuario);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
            return false;
        }

        public bool ActualizarUsuario(Usuario request)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(request.Id);
                if (usuario != null)
                {
                    usuario.Nombre = request.Nombre;
                    usuario.UserName = request.UserName;
                    usuario.Password = request.Password;
                    usuario.IdRol = request.IdRol;

                    _context.Usuarios.Update(usuario);
                    int result = _context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
            return false;
        }

    }
}
