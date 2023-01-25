using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNM
{
    internal class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Pais { get; set; }
        public ICollection<LivroAutor> LivrosAutores { get; set; }
    }
}
