using System;

namespace BinaryLab.CopaFilmes.Filme.Dominio.Entidades
{
    public class Filme
    {
        public string Id { get; }
        public string Nome { get; }
        public int Ano { get; }
        public decimal Nota { get; }

        public Filme(string id, string nome, int ano, decimal nota)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Nome = nome ?? throw new ArgumentException(nameof(nome));
            Ano = ano > 0 ? ano : throw new ArgumentOutOfRangeException(nameof(ano));
            Nota = nota > 0 ? nota : throw new ArgumentOutOfRangeException(nameof(nota));
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