using System;

namespace BinaryLab.CopaFilmes.Filme.Dominio.Entidades
{
    public class Filme
    {
        public string Id { get; }
        public string Titulo { get; }
        public int Ano { get; }
        public decimal Nota { get; }

        public Filme(string id, string titulo, int ano, decimal nota)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Titulo = titulo ?? throw new ArgumentException(nameof(titulo));
            Ano = ano > 0 ? ano : throw new ArgumentOutOfRangeException(nameof(ano));
            Nota = nota > 0 ? nota : throw new ArgumentOutOfRangeException(nameof(nota));
        }

        public static Filme Create(string id, string titulo, int ano, decimal nota) =>
            new Filme(id, titulo, ano, nota);

        public override bool Equals(object obj)
        {
            var objComparacao = obj as Filme;
            if (objComparacao == null)
                return false;

            return objComparacao.Id.Equals(Id) && objComparacao.Titulo.Equals(Titulo) &&
                          objComparacao.Ano.Equals(Ano) && objComparacao.Nota.Equals(Nota);
        }
    }
}