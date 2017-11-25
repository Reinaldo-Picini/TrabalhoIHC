
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoIHC.Models;
using TrabalhoIHC.Repositorio;

namespace TrabalhoIHC.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarPet()
        {

            IList<Pet> ListaDePets = new List<Pet>();
            return View(ListaDePets);
        }

        public ActionResult CadPet()
        {
            return View(new Pet());
        }

        [HttpPost]
        public ActionResult CadPet(Pet objPets)
        {
            if (ModelState.IsValid)
            {

                Random p = new Random();
                objPets.PetId = p.Next(1, 99999);
                Pet.Add(objPets);
                return RedirectToAction("ListarPet");
                TempData["Mensagem"] = "Gravado com sucesso";
            }
            ViewBag.Mensagem = "Preencha os campos obrigatorios";
            return View(objPets);

        }
        [HttpGet]
        public ActionResult Alterar(int id) 
        {
            Pet pets = Pet.First(id); 
            return View(pets);
        }
        
        public ActionResult Apagar(int id)
        {
            Pet objPets = Pet.First(id);
            return View(objPets);
        }
    }
}