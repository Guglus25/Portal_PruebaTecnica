using Portal_PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal_PruebaTecnica.Controllers
{
    public class CadenaController : Controller
    {
        // GET: Cadena
       
        [HttpGet]
        public ActionResult Cadena()
        {
            clsCadena oCadena = new clsCadena();

            string strIteraciones;

            oCadena.strIteracion = oCadena.Prueba_Tecnica("MVM INGENIERIA DE SOFTWARE", 1);

            return View("Cadena", oCadena);
        }
    }
}