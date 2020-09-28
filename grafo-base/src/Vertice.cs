using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    public class Vertice
    {
        public string Id { get; private set; }
        private List<Ligacao> ListaAdjacencia = new List<Ligacao>();

        public Vertice(string id)
        {
            this.Id = id;
        }
        public void AdicionarAdjacente(Vertice vertice, int peso)
        {
            this.ListaAdjacencia.Add(new Ligacao(vertice, peso));
        }

        public void RemoverAdjacente(string id)
        {
            this.ListaAdjacencia.RemoveAll(v => v.getVerticeId() == id);
        }
        public int GetGrau()
        {
            return this.ListaAdjacencia.Count;
        }

        public bool IsAdjacente(Vertice v2)
        {
            return this.ListaAdjacencia.Any(adjacente => adjacente.getVerticeId() == v2.Id);
        }

        public bool IsIsolado() {
            return this.GetGrau() == 0;
        }

        public bool IsPendente() {
            return this.GetGrau() == 1;
        }

        private void ListarAdjacentes()
        {
            foreach (Ligacao v in this.ListaAdjacencia)
            {
                Console.Write(v);
            }
        }

        public override string ToString()
        {
            string ligacoes = "";

            foreach (Ligacao v in this.ListaAdjacencia)
            {
                ligacoes += this.Id + " -> " + v + "\n";
            }

            return ligacoes;
        }
    }
}
