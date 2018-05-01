using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Livraria_Back.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria_Back.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    //[Route("api/[Controller]")]
    public class LivroController : Controller
    {
        public static WebConfig webConfig { get; set; }
        LivroDataAccessLayer objLivro;
        public LivroController(WebConfig webconfig)
        {
            webConfig = webconfig;
            objLivro = new LivroDataAccessLayer(webConfig);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("api/[Controller]/Index")]
        public IEnumerable<Livro> Index()
        {
            return objLivro.GetAllLivros();
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("api/[Controller]/GetById/{id:int}")]
        public Livro GetById(int id)
        {
            return objLivro.GetById(id);
        }


        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("api/[Controller]/Create")]
        public int Create([FromBody] Livro livro)
        {
            //livro.LivroId = null;
             return objLivro.AddLivro(livro);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("api/[Controller]/Update")]
        public int Update([FromBody] Livro livro)
        {
            return objLivro.UpdateLivro(livro);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("api/[Controller]/Delete")]
        public int Delete([FromBody] int LivroId)
        {
            return objLivro.DeleteLivro(LivroId);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("api/[Controller]/SearchByName/{Nome}")]
        public List<Livro> SearchByName(string Nome)
        {
            return objLivro.SearchByName(Nome);
        }



    }
}