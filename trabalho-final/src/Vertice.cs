using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{

    public class Vertice
    {
        public string Id { get; set; }
        public List<Aresta> ListaAdjacencia = new List<Aresta>();
        public virtual string Cor { get; private set; }
        public int TempoEntrada { get; set; }
        public int TempoSaida { get; set; }
        public Vertice Chefe { get; set; }

        // -> Contrutores, constroi uma classe
        public Vertice(string id, Vertice chefe)
        {
            this.Id = id;
            this.TempoEntrada = 0;
            this.TempoSaida = 0;
            this.Chefe = this;
        }
        public Vertice(string id)
        {
            this.Id = id;
            this.TempoEntrada = 0;
            this.TempoSaida = 0;
            this.Chefe = this;
        }

        public Vertice()
        {
            this.TempoEntrada = 0;
            this.TempoSaida = 0;
            this.Chefe = this;
        }

        // -> Adiciona um vértice a lista de adjacência, junto ao peso
        public void AdicionarAdjacente(Vertice vertice, int peso)
        {
            // -> Adiciona uma nova aresta na lista de adjacência
            this.ListaAdjacencia.Add(new Aresta(vertice, peso));
        }

        // -> Remove um vértice adjacente e todas suas arestas
        public void RemoverAdjacente(Vertice v)
        {
            // -> Remove todas as incidências de v na lista de adjacência
            this.ListaAdjacencia.RemoveAll(a => a.Vertice.Id == v.Id);
        }

        // -> Ordena a lista de vértice de acordo com o formado dos Ids dos vértices
        public void OrdenarAdjacentes() {
            int aux;

            if(int.TryParse(this.Id, out aux)) {
                this.ListaAdjacencia.Sort((a1, a2) => int.Parse(a1.Vertice.Id) - int.Parse(a2.Vertice.Id));
            }
            else {
                this.ListaAdjacencia.Sort((a1, a2) => a1.Vertice.Id.CompareTo(a2.Vertice.Id));
            }
        }

        // -> Obtem o grau de um vértices
        public int GetGrau()
        {
            return this.ListaAdjacencia.Count;
        }

        // -> Testa se um vértice tem grau 0 e retorna se é isolado
        public bool IsIsolado()
        {
            return GetGrau() == 0;
        }

        // -> Testa se um vértice tem grau 1 e retorna se é pendente
        public bool IsPendente()
        {
            return GetGrau() == 1;
        }

        // -> busca na lista de adjacência de um vértice se ha incidência de v
        public bool IsAdjacente(Vertice v)
        {
            // -> Percorre toda a lista de adjacência e retorna se encontrar v
            return this.ListaAdjacencia.Any(a => a.Vertice.Id == v.Id);
        }

        // -> Obtem todos os pesos de que ligam this em v 
        public int[] GetPesos(Vertice v)
        {
            // -> Obtem todos os pesos de um vértice adjacente específico
            return this.ListaAdjacencia.Where(a => a.Vertice.Id == v.Id).Select(a => a.Peso).ToArray();
        }

        // -> Verifica se há arestas paralelas 
        public bool HasArestasParalela()
        {
            // -> Agrupa em listas todos os vértices iguais e retorna se possui mais de uma incidência
            return this.ListaAdjacencia.GroupBy(a => a.Vertice.Id).Any(v => v.Count() > 1);
        }

        // -> Verifica se loop em um vértice
        public bool HasLoop()
        {
            // -> Retorna se exite alguma aresta ligando a si mesmo
            return this.ListaAdjacencia.Any(a => a.Vertice.Id == this.Id);
        }

        // -> Existe todos o vértices adijacentes
        public void ListarAdjacentes()
        {
            foreach (Aresta v in this.ListaAdjacencia)
            {
                Console.Write(v);
            }
        }

        // -> Reseta todos os tempos para DFS
        public void ResetTempos()
        {
            this.TempoEntrada = 0;
            this.TempoSaida = 0;
        }

        // -> Muda a cor do vértice this para branco para DFS
        public void SetCorBranco()
        {
            this.Cor = "Branco";
        }

        // -> Muda a cor do vértice this para cinza para DFS
        public void SetCorCinza()
        {
            this.Cor = "Cinza";
        }

        // -> Muda a cor do vértice this para preto para DFS
        public void SetCorPreto()
        {
            this.Cor = "Preto";
        }

        // -> Obtem o Id, tempo entrada e saída
        public string GetTempos()
        {
            return this.Id = ": E: " + this.TempoEntrada + "S: " + this.TempoSaida;
        }

        // -> retorna todas as arestas adjacêntes
        public List<string> GetArestas()
        {
            return this.ListaAdjacencia.Select(a => "[" + a.Id + "] " +  this.Id + " -> " + a  + "\n").ToList();
        }

        public override string ToString()
        {
            string ligacoes = "";
            this.ListaAdjacencia.ForEach(a => ligacoes += "[" + a.Id + "] " + this.Id + " -> " + a + "\n");
            return (ligacoes != "") ? ligacoes : "[null] " + this.Id + "\n";
        }
    }
}
