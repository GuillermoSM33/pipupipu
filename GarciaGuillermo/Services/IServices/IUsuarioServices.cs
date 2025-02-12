using GarciaGuillermo.Models.Domain;
using Microsoft.Identity.Client.Extensibility;

namespace GarciaGuillermo.Services.IServices
{
    public interface IUsuarioServices
    {
        bool CrearUsuario(Usuario request);
        public Usuario ObtenerUsuarioPorId(int id);
        public bool ActualizarUsuario(Usuario request);
        public List<Usuario> ObtenerUsuario();
    }
}
