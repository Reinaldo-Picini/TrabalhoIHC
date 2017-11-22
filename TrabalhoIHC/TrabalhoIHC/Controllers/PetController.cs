using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoIHC.Models;

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

            IList<Pet> ListaDePets = PetReposit.Pet;
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
                PetReposit.Pet.Add(objPets);
                return RedirectToAction("ListarPet");
                TempData["Mensagem"] = "Gravado com sucesso";
            }
            ViewBag.Mensagem = "Preencha os campos obrigatorios";
            return View(objPets);

        }

        public ActionResult Alterar(int id) // esse id e o da rota, para aparecer na url
        {
            Pet pets = PetReposit.Pet.First(p => p.PetId == id); // esse id  e a mesma coisa
            return View(pets);
        }


        [HttpPost]
        public ActionResult Alterar(Pet objPet)
        {
            if (ModelState.IsValid)
            {

                //buscar o objeto no banco para poder alterar
                Pet petDoBanco = PetReposit.Pet.First(p => p.PetId == objPet.PetId);

                //colocando os valos que chegou no objeto novo no objeto que esta no banco

                petDoBanco.Nome = objPet.Nome;
                petDoBanco.Raca = objPet.Raca;
                petDoBanco.Idade = objPet.Idade;
                petDoBanco.Sexo = objPet.Sexo;
                petDoBanco.NomeDono = objPet.NomeDono;
                petDoBanco.Endereco = objPet.Endereco;

                return RedirectToAction("Listar");

            }

            TempData["Mensagem"] = "Preencher todos os campos obrigatirio.";
            return View(objPet);


        }
        public ActionResult Apagar(int id)
        {
            Pet objPets = PetReposit.Pet.First(p => p.PetId == id);
            return View(objPets);
        }

        [HttpPost]
        public ActionResult Apagar(Pet objPets)
        {
            Pet petBanco = PetReposit.Pet.First(p => p.PetId == objPets.PetId);

            PetReposit.Pet.Remove(petBanco);

            return RedirectToAction("Listar");

        }
    }
}