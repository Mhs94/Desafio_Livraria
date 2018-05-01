using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using Newtonsoft.Json;

namespace Livraria_Front.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            
            return View();
        }
        /*public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Livro livro)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }*/
        public  async Task<JsonResult> GetbyName(string Nome)
        {

            Livro livro = null;
            
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("http://localhost:55972api/Livro/Index"))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                livro = JsonConvert.DeserializeObject<Livro>(result);
                // ... Display the result.
                
            }
            return Json(livro, JsonRequestBehavior.AllowGet);
        }
        /*public JsonResult Update(Livro livro)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        */
    }
}