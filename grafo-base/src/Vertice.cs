using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{

    public class Vertice
    {
        public string Id { get; private set; }
        public List<Aresta> ListaAdjacencia = new List<Aresta>();
        public string Cor { get; private set; }
        public int TempoEntrada { get; set; }
        public int TempoSaida { get; set; }
        

        public Vertice(string id)
        {
            this.Id = id;
            this.TempoEntrada = 0;
            this.TempoSaida = 0;
        }

        public void AdicionarAdjacente(Vertice vertice, int peso)
        {
            this.ListaAdjacencia.Add(new Aresta(vertice, peso));
        }

        public void RemoverAdjacente(Vertice v)
        {
            // -> Remove todas as incidências de v na lista de adjacência
            this.ListaAdjacencia.RemoveAll(a => a.Vertice.Id == v.Id);
        }

        public int GetGrau()
        {
            return this.ListaAdjacencia.Count;
        }

        public bool IsIsolado()
        {
            return GetGrau() == 0;
        }

        public bool IsPendente()
        {
            return GetGrau() == 1;
        }

        public bool IsAdjacente(Vertice v)
        {
            // -> Percorre toda a lista de adjacência e retorna se encontrar v
            return this.ListaAdjacencia.Any(a => a.Vertice.Id == v.Id);
        }

        public int[] GetPesos(Vertice v)
        {
            // -> Obtem todos os pesos de um vértice adjacente específico
            return this.ListaAdjacencia.Where(a => a.Vertice.Id == v.Id).Select(a => a.Peso).ToArray();
        }

        public bool HasArestasParalela()
        {
            // -> Agrupa em listas todos os vértices iguais e retorna se possui mais de uma incidência
            return this.ListaAdjacencia.GroupBy(a => a.Vertice.Id).Any(v => v.Count() > 1);
        }

        public bool HasLoop()
        {
            // -> Retorna se exite alguma aresta ligando a si mesmo
            return this.ListaAdjacencia.Any(a => a.Vertice.Id == this.Id);
        }

        public void ListarAdjacentes()
        {
            foreach (Aresta v in this.ListaAdjacencia)
            {
                Console.Write(v);
            }
        }

        public void ResetTempos() {
            this.TempoEntrada = 0;
            this.TempoSaida = 0;
        }

        public void SetCorBranco()
        {
            this.Cor = "Branco";
        }

        public void SetCorCinza()
        {
            this.Cor = "Cinza";
        }

        public void SetCorPreto()
        {
            this.Cor = "Preto";
        }

        public List<string> GetArestas()
        {
            return this.ListaAdjacencia.Select(a => $"[{a.Id}] {this.Id} -> {a} \n").ToList();
        }

        public override string ToString()
        {
            string ligacoes = "";
            this.ListaAdjacencia.ForEach(a => ligacoes += $"[{a.Id}] {this.Id} -> {a} \n");
            return (ligacoes != "") ? ligacoes : "[null] " + this.Id + "\n";
        }
    }
}
