using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo {
    
    public class Grafo {
        public List<Vertice> Vertices = new List<Vertice>();

        public Grafo() {
            Aresta.IdCount = 1;
        }
        
        public void InserirVertice(Vertice v) {
            if(!(v is null)) this.Vertices.Add(v);
        }    
        public void InserirAresta(Vertice de, Vertice para, int peso) {
            // -> busca se os vértices já estão presentes no grafo
            Vertice auxDe = this.Vertices.Find(v => v.Id == de.Id);

            if (auxDe is null) {
                this.InserirVertice(de);
                auxDe = de;
            }

            // -> busca se os vértices já estão presentes no grafo
            Vertice auxPara = this.Vertices.Find(v => v.Id == para.Id);

            if (auxPara is null) {
                this.InserirVertice(para);
                auxPara = para;
            }

            auxDe.AdicionarAdjacente(auxPara, peso);
        }

        public Vertice GetVertice(string id) {
            return this.Vertices.Find(v => v.Id == id);
        }

        public bool IsAdjacente(Vertice v1, Vertice v2) {
            return v1.IsAdjacente(v2);
        }

        public int GetGrau(Vertice v1) {
            return v1.GetGrau();
        }

        public bool IsIsolado(Vertice v1) {
            return v1.IsIsolado();
        }

        public bool IsPendente(Vertice v1) {
            return v1.IsPendente();
        }

        public bool HasArestasParalela() {
            return this.Vertices.Any(v => v.HasArestasParalela());
        }

        public bool HasLoop() {
            return this.Vertices.Any(v => v.HasLoop());
        }

        public bool IsRegular() {
            Vertice auxVertice = this.Vertices[0];
            // -> se não existir nenhum vértice com grau diferente do auxiliar return true
            return !this.Vertices.Any(v => v.GetGrau() != auxVertice.GetGrau());
        }

        public bool IsNulo() {
            // -> se não achar nenhum vértice que não seja isolado return true
            return !this.Vertices.Any(v => !this.IsIsolado(v));
        }

        public bool IsCompleto() {
            int auxGrau = this.Vertices[0].GetGrau();
            return (this.IsRegular() && !this.HasArestasParalela() && !this.HasLoop() && (auxGrau == Vertices.Count - 1));
        }

        public bool IsConexo() {
            BuscaProfundidade buscaProfundidade = new BuscaProfundidade();
            return buscaProfundidade.Buscar(this) == 1;
        }

        public bool IsEuleriano() {
            return false;
        }

        public bool IsUnicursal() {
            return false;
        }

        public int getQuantidadeVertices() {
            return this.Vertices.Count;
        }

        public Vertice getVerticeMaiorGrau() {
            // -> Ordena a lista de vertice pelos graus de forma descrescente e retorna o primeiro
            return this.Vertices.OrderByDescending(v => this.GetGrau(v)).ToList()[0];
        }

        public int[] GetPesos(Vertice v1, Vertice v2) {
            return v1.GetPesos(v2);
        }

        public void ordernarVertices(string tipoOrdenamento) {
            tipoOrdenamento = tipoOrdenamento.ToLower();

            switch(tipoOrdenamento) {
                case "a ->": 
                    this.Vertices.Sort((v1, v2) => v1.Id.CompareTo(v2.Id));
                break;
                
                case "a <-":
                    this.Vertices.Sort((v1, v2) => v2.Id.CompareTo(v1.Id));
                break;

                case "1 ->": 
                    this.Vertices.Sort((v1, v2) => int.Parse(v1.Id) - int.Parse(v2.Id));
                break;
                
                case "1 <-": 
                    this.Vertices.Sort((v1, v2) => int.Parse(v2.Id) - int.Parse(v1.Id));
                break;
   
                default:
                    Console.WriteLine("Parâmetro de orndenação inválido");
                break;
            }
        }

        public void imprimirVertices() {
            // -> Lista todos os vértices e seus respectivos graus
            this.Vertices.ForEach(v => System.Console.WriteLine($"{v.Id}: {this.GetGrau(v)}"));
        }

        public void ImprimirGrafo() {
            this.Vertices.ForEach(v => Console.Write(v));
        }

        public void ImprimirMatriz() {            
            Vertices.ForEach(v1 => {Vertices.ForEach(v2 => {
                String aux = String.Join(",", this.GetPesos(v1, v2));
                aux = (aux == "") ? "0" : aux;
                Console.Write($"[{aux}] ");
            });
                Console.WriteLine();
            });
        }
    }
}
