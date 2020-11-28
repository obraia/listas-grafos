using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{

    public class Professor
    {
        public static int CuntId = 1;
        public List<Aresta> ListaAdjacencia = new List<Aresta>();
        public string Id { get; private set; }
        public int Periodo { get; private set; }
        public string Nome { get; private set; }
        public string Disciplina { get; private set; }
        public Cor Cor { get; private set; }

        // -> Contrutor, constroi uma classe
        public Professor(string nome, string disciplina, string periodo)
        {
            this.Id = CuntId.ToString();
            this.Nome = nome;
            this.Disciplina = disciplina;
            this.Periodo = int.Parse(periodo);
            this.Cor = new Cor("", "", "");
            CuntId++;
        }

        // -> Define a cor para a coloração
        public void SetCor(Cor cor)
        {
            this.Cor = cor;
        }

        // -> Adiciona um professor à lista de adjacência
        public void AdicionarAdjacente(Professor professor)
        {
            this.ListaAdjacencia.Add(new Aresta(professor));
        }

        // -> Remove um professor adjacente e todas suas arestas
        public void RemoverAdjacente(Professor p)
        {
            // -> Remove todas as incidências de p na lista de adjacência
            this.ListaAdjacencia.RemoveAll(a => a.Professor.Id == p.Id);
        }

        // -> busca na lista de adjacência de um vértice se ha incidência de v
        public bool IsAdjacente(Professor p)
        {
            // -> Percorre toda a lista de adjacência e retorna se encontrar v
            return this.ListaAdjacencia.Any(a => a.Professor.Id == p.Id);
        }

        // -> Existe todos o vértices adjacentes
        public void ListarAdjacentes()
        {
            foreach (Aresta v in this.ListaAdjacencia)
            {
                Console.Write(v);
            }
        }

        // -> Retorna todas as arestas adjacêntes
        public List<string> GetArestas()
        {
            return this.ListaAdjacencia.Select(a => "[" + a.Id + "] " + this.Id + " -> " + a + "\n").ToList();
        }

        public override string ToString()
        {
            string ligacoes = "";
            this.ListaAdjacencia.ForEach(a => ligacoes += "[" + a.Id + "] " + this.Nome + " -> " + a + "\n");
            return (ligacoes != "") ? ligacoes : "[null] " + this.Nome + "\n";
        }
    }
}
