using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Livro
    {

        public int LivroId { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int? AnoPublicacao { get; set; }
    }
}
