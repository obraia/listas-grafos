using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo {

    public class Vertice  {
        public string Id { get; private set; }
        public List<Aresta> ListaAdjacencia = new List<Aresta>();
        public string Cor = "Branco";
        public Vertice(string id) {
            this.Id = id;
        }

        public void AdicionarAdjacente(Vertice vertice, int peso) {
            this.ListaAdjacencia.Add(new Aresta(vertice, peso));
        }

        public void RemoverAdjacente(string id) {
            this.ListaAdjacencia.RemoveAll(v => v.getVerticeId() == id);
        }

        public int GetGrau() {
            return this.ListaAdjacencia.Count;
        }

        public bool IsIsolado() {
            return GetGrau() == 0;
        }

        public bool IsPendente() {
            return GetGrau() == 1;
        }

        public bool IsAdjacente(Vertice v2) {
            return this.ListaAdjacencia.Any(adj => adj.getVerticeId() == v2.Id);
        }

        public int[] GetPesos(Vertice v2) {
            // -> Obtem todos os pesos de um vértice adjacente específico
            return this.ListaAdjacencia.Where(a => a.Vertice.Id == v2.Id).Select(a => a.Peso).ToArray();
        }

        public bool HasArestasParalela() {
            // -> Agrupa em listas todos os vértices iguais e retorna se possui mais de uma incidência
            return this.ListaAdjacencia.GroupBy(a => a.Vertice.Id).Any(v => v.Count() > 1);
        }

        public bool HasLoop() {
            // -> Retorna se exite alguma aresta ligando a si mesmo
            return this.ListaAdjacencia.Any(a => a.Vertice.Id == this.Id);
        }

        private void ListarAdjacentes() {
            foreach (Aresta v in this.ListaAdjacencia) {
                Console.Write(v);
            }
        }

        public List<string> GetArestas() {
            return this.ListaAdjacencia.Select(a => $"[{a.Id}] {this.Id} -> {a} \n").ToList();
        }

        public override string ToString() {
            string ligacoes = "";
            this.ListaAdjacencia.ForEach(a => ligacoes += $"[{a.Id}] {this.Id} -> {a} \n");
            return (ligacoes != "") ? ligacoes : "[null] " + this.Id + "\n";
        }
    }
}
