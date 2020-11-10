using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    public class Vertice
    {
        public string Id { get; private set; }
        private List<Aresta> ListaAdjacencia = new List<Aresta>();

        public Vertice(string id)
        {
            this.Id = id;
        }

        public void AdicionarAdjacente(Vertice vertice, int peso)
        {
            this.ListaAdjacencia.Add(new Aresta(vertice, peso));
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
            return this.ListaAdjacencia.Any(adj => adj.getVerticeId() == v2.Id);
        }

        public bool IsIsolado() {
            return this.GetGrau() == 0;
        }

        public bool IsPendente() {
            return this.GetGrau() == 1;
        }

        private void ListarAdjacentes()
        {
            foreach (Aresta v in this.ListaAdjacencia)
            {
                Console.Write(v);
            }
        }

        public override string ToString()
        {
            string ligacoes = "";

            foreach (Aresta v in this.ListaAdjacencia)
            {
                ligacoes += this.Id + " -> " + v + "\n";
            }

            return ligacoes;
        }
    }
}
