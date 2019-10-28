
using Portal_PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Portal_PruebaTecnica.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            RootObject oEstructura = new RootObject();
            return View("Index", oEstructura);
        }

        [HttpGet]
        public async Task<ActionResult> Buscar(string alpha3Code)
        {
            RootObject oEstructura = new RootObject();

            var result = ValidarISO(alpha3Code);
            if (result == "")
            {
                using (var Client = new HttpClient())
                {



                    Client.BaseAddress = new Uri("https://restcountries.eu/rest/v2/alpha/");

                    var responseTaks = Client.GetAsync(alpha3Code);
                    responseTaks.Wait();
                    var resp = responseTaks.Result;

                    if (resp.IsSuccessStatusCode)
                    {
                        var tabla = await resp.Content.ReadAsStringAsync();
                        oEstructura = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(tabla);

                    }

                }
            }
            else
            {
                oEstructura.alpha3Code = result;

            }
            return View("Index", oEstructura);

        }

        private string ValidarISO(string alpha3Code)
        {
            string strResp = "";


            if (alpha3Code.Length != 3)
            {
                strResp = "El código ISO debe de ser de 3 caracteres";
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(alpha3Code, @"^[a-zA-Z0-9]+$"))
            {
                strResp = "El código ISO debe ser Alfanumerico";
            }

            return strResp;
        }


    }
}