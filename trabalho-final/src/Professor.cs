using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{

    public class Professor
    {
        public static int CuntId = 1;
        public List<Aresta> ListaAdjacencia = new List<Aresta>();
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Disciplina { get; set; }
        public int Periodo { get; set; }
        public Cor Cor { get; private set; }

        // -> Contrutor, constroi uma classe
        public Professor(string nome, string disciplina, string periodo)
        {
            this.Id = CuntId.ToString();
            this.Nome = nome;
            this.Disciplina = disciplina;
            this.Periodo = int.Parse(periodo);

            CuntId++;
        }

        public void SetCor(Cor cor)
        {
            this.Cor = cor;
            // this.ListaAdjacencia.ForEach(a =>  (Professor)a.Vertice.Cor = cor)
        }

        // -> Adiciona um vértice a lista de adjacência, junto ao peso
        public void AdicionarAdjacente(Professor professor)
        {
            // -> Adiciona uma nova aresta na lista de adjacência
            this.ListaAdjacencia.Add(new Aresta(professor));
        }

        // -> Remove um vértice adjacente e todas suas arestas
        public void RemoverAdjacente(Professor p)
        {
            // -> Remove todas as incidências de v na lista de adjacência
            this.ListaAdjacencia.RemoveAll(a => a.Professor.Id == p.Id);
        }

        // -> Ordena a lista de vértice de acordo com o formado dos Ids dos vértices
        public void OrdenarAdjacentes() {
            int aux;

            if(int.TryParse(this.Id, out aux)) {
                this.ListaAdjacencia.Sort((a1, a2) => int.Parse(a1.Professor.Id) - int.Parse(a2.Professor.Id));
            }
            else {
                this.ListaAdjacencia.Sort((a1, a2) => a1.Professor.Id.CompareTo(a2.Professor.Id));
            }
        }

        // -> busca na lista de adjacência de um vértice se ha incidência de v
        public bool IsAdjacente(Professor p)
        {
            // -> Percorre toda a lista de adjacência e retorna se encontrar v
            return this.ListaAdjacencia.Any(a => a.Professor.Id == p.Id);
        }

        // -> Existe todos o vértices adijacentes
        public void ListarAdjacentes()
        {
            foreach (Aresta v in this.ListaAdjacencia)
            {
                Console.Write(v);
            }
        }

        // -> retorna todas as arestas adjacêntes
        public List<string> GetArestas()
        {
            return this.ListaAdjacencia.Select(a => "[" + a.Id + "] " +  this.Id + " -> " + a  + "\n").ToList();
        }

        public override string ToString()
        {
            string ligacoes = "";
            this.ListaAdjacencia.ForEach(a => ligacoes += "[" + a.Id + "] " + this.Nome + " -> " + a + "\n");
            return (ligacoes != "") ? ligacoes : "[null] " + this.Nome + "\n";
        }
    }
}
