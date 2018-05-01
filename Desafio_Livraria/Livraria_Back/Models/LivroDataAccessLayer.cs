using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria_Back.Models;
using Domain.Models;

namespace Livraria_Back.Models
{
    public class LivroDataAccessLayer
    {

        static WebConfig webConfig { get; set; }
        LivrariaContext db;



        public LivroDataAccessLayer(WebConfig webconfig)
        {
            webConfig = webconfig;
            db = new LivrariaContext(webConfig);
            
        }
         
        public IEnumerable<Livro> GetAllLivros()
        {
            try
            {
                return db.Livro.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Livro GetById(int livroid)
        {
            try
            {
                return db.Livro.FirstOrDefault(t => t.LivroId==livroid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int AddLivro( Livro livro)
        {
            try
            {
                db.Livro.Add(livro);
                db.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int UpdateLivro(Livro livro)
        {
            try
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public List<Livro> SearchByName(string nome)
        {
            try
            {
               var livros = db.Livro.Where(t => t.Nome.Contains(nome)).ToList<Livro>();
               return livros;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public int DeleteLivro(int id)
        {
            try
            {
                Livro livro = db.Livro.Find(id);
                db.Livro.Remove(livro);
                db.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }



    }
}
