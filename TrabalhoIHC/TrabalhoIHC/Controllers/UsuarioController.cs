using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoIHC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult CadUsuario()
        {
            ViewBag.Message = "Cadastro de Usuários";
            return View();
        }

        // GET: Usuario
        public ActionResult Logar()
        {
            ViewBag.Message = "Logar";
            return View();
        }
        [HttpPost]
        public ActionResult Logar(string email, string senha)
        {

            return RedirectToAction("ListarPet", "Pet");
        }
    }
}