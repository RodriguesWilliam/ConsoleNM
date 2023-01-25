using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNM
{
    internal class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public DateTime Lancamento { get; set; }
        public string ISBN { get; set; }
        public decimal Preco { get; set; }
        public ICollection<LivroAutor> LivrosAutores { get; set; }
    }
}
