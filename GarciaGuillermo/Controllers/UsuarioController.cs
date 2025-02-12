using GarciaGuillermo.Models.Domain;
using GarciaGuillermo.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GarciaGuillermo.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        public IActionResult Index()
        {
            var result = _usuarioServices.ObtenerUsuario();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Crear(Usuario request)
        {
            _usuarioServices.CrearUsuario(request);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Editar(int id)
        {
            var result = _usuarioServices.ObtenerUsuarioPorId(id);
            return View(result);
        }
    }
}
