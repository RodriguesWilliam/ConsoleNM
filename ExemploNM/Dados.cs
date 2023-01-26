using Microsoft.EntityFrameworkCore;
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
        public static void AtualizarDados()
        {
            using (var context = new AppDbContext())
            {
                //Localiza o livro a atualizar
                var livro = context.Livros
                    .Include(p => p.LivrosAutores)
                    .Single(p => p.Titulo == "Criando aplicações Mobile");
                //localiza o autor a ser usado           
                var novoAutor = context.Autores.Single(p => p.Nome == "Martin");

                //inclui um novo autor para o livro selecionado              
                livro.LivrosAutores.Add(new LivroAutor
                {
                    Livro = livro,
                    Autor = novoAutor,
                });
                context.SaveChanges();
            }
        }
        public static void ExibeDados(AppDbContext context)
        {
            Console.WriteLine($"Livros e Autores");
            var livros = context.Livros
                            .Include(e => e.LivrosAutores)
                            .ThenInclude(e => e.Autor)
                           .ToList();
            foreach (var livro in livros)
            {
                Console.WriteLine($"  Livro {livro.Titulo}");
                foreach (var autor in livro.LivrosAutores.Select(e => e.Autor))
                {
                    Console.WriteLine($"    autor: {autor.Nome} {autor.SobreNome}");
                }
            }
            Console.WriteLine();
        }
    }

}
