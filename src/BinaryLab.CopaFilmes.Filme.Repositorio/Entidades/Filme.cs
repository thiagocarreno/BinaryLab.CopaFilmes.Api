using System;
using BinaryLab.CopaFilmes.Repositorio.Entidades;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Repositorio.Entidades
{
    public class Filme : Entidade<string>
    {
        public string Nome { get; set; }
        public int Ano { get; set;  }
        public decimal Nota { get; set; }

        public Filme([NotNull] string id, string nome, int ano, decimal nota)
        {
            Id = id;
            Nome = nome;
            Ano = ano;
            Nota = nota;
        }

        public static Filme Create(string id, string nome, int ano, decimal nota) =>
            new Filme(id, nome, ano, nota);

        public override bool Equals(object obj)
        {
            var objComparacao = obj as Filme;
            if (objComparacao == null)
                return false;

            return objComparacao.Id.Equals(Id) && objComparacao.Nome.Equals(Nome) &&
                   objComparacao.Ano.Equals(Ano) && objComparacao.Nota.Equals(Nota);
        }
    }
}