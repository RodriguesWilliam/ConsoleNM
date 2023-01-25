using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNM
{
    internal class LivroAutor
    {
        public int LivroId { get; set; }
        public int AutorId { get; set; }

        public Livro Livro { get; set; }
        public Autor Autor { get; set; }
    }
}
