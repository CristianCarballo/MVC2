using MVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            Persona p = new Persona(300, "Elsa", "Lamin", 20);
            GestorPersonas gp = new GestorPersonas();
            gp.agregarPersona(p);
            return View();
        }

        public ActionResult Listar()
        {
            GestorPersonas gp = new GestorPersonas();
            List<Persona> lista = gp.obtenerPersonas();

            string listado = "";
            foreach (Persona x in lista)
            {
                listado += x.ToString() + "\n";
            }

            return View("Listar","",listado);
        }
    }
}