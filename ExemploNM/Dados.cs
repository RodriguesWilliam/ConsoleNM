using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNM
{
    internal class Dados
    {
        public static void IncluirDados()
        {
            using (var context = new AppDbContext())
            {
                var livro = new Livro
                {
                    Titulo = "Criando aplicações Mobile",
                    Lancamento = new DateTime(2017, 1, 1),
                    ISBN = "978-3-16-148410-0",
                    Preco = 220
                };
                var autor = new Autor { Nome = "Gerald", SobreNome = "Versalious", Pais = "EUA" };
                livro.LivrosAutores = new List<LivroAutor>
                {
                  new LivroAutor {
                    Autor = autor,
                    Livro = livro,
                  }
                };
                //Inclui o livro e seus relacionamentos
                context.Livros.Add(livro);
                context.SaveChanges();
            }
        }
    }

}
