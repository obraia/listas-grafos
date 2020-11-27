using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    public class Grafo
    {
        public List<Vertice> Vertices = new List<Vertice>();
        public string[] ArquivoGerador;

        // -> Método estático para criar um grafo
        public static Grafo CriarGrafo(string[] linhas)
        {
            Grafo grafo = new Grafo();

            for (int i = 1; i < linhas.Length; i++)
            {
                string[] aux = linhas[i].Split(';');

                Vertice v1 = new Vertice(aux[0]);

                // -> Tratar vértices isolados
                if (aux.Length > 1)
                {
                    Vertice v2 = new Vertice(aux[1]);
                    int peso = int.Parse(aux[2]);

                    if (aux.Length == 3)
                    {
                        grafo.InserirAresta(v1, v2, peso);
                        // -> Tratar arestas paralelas, caso tiver os mesmo id não adicona a segunda aresta
                        if (v1.Id != v2.Id) grafo.InserirAresta(v2, v1, peso);
                    }
                    else if (aux[3] == "1") grafo.InserirAresta(v1, v2, peso);
                    else grafo.InserirAresta(v2, v1, peso);

                    Aresta.IdCount++;
                }
                else grafo.InserirVertice(v1);
            }

            grafo.ArquivoGerador = linhas;
            grafo.OrdernarVertices();

            return grafo;
        }

        // -> Contrutor, inicia contador da aresta com 1
        public Grafo()
        {
            Aresta.IdCount = 1;
        }

        // -> Insere um vértice na lista de vértices do grafo
        public void InserirVertice(Vertice v)
        {
            if (!(v is null)) this.Vertices.Add(v);
        }

        // -> Remove um vértice totalmente de um grafo
        public void RemoverVertice(Vertice v)
        {
            // -> remove v da lista de vértices e em todos que tem como adjacente
            if (!(v is null))
            {
                this.Vertices.Remove(v);
                this.Vertices.ForEach(v1 => v1.RemoverAdjacente(v));
            }
        }

        // -> Insere ua aresta composta por dois vértices e o peso
        public void InserirAresta(Vertice de, Vertice para, int peso)
        {
            // -> busca se os vértices já estão presentes no grafo
            Vertice auxDe = this.Vertices.Find(v => v.Id == de.Id);

            if (auxDe is null)
            {
                this.InserirVertice(de);
                auxDe = de;
            }

            // -> busca se os vértices já estão presentes no grafo
            Vertice auxPara = this.Vertices.Find(v => v.Id == para.Id);

            if (auxPara is null)
            {
                this.InserirVertice(para);
                auxPara = para;
            }

            auxDe.AdicionarAdjacente(auxPara, peso);
        }

        // -> Retorna um vértice a partir do seu id
        public Vertice GetVertice(string id)
        {
            return this.Vertices.Find(v => v.Id == id);
        }

        // -> Verifica se há adjacência entr dois vértices
        public bool IsAdjacente(Vertice v1, Vertice v2)
        {
            return v1.IsAdjacente(v2);
        }

        // -> Obtem o grau de saida de um vertice em um grafo
        // direcionado ou o grau normal para um grafo não direcionado
        public int GetGrau(Vertice v)
        {
            return v.GetGrau();
        }

        // -> Obtem o grau de entrada de um vértice
        public int GetGrauEntrada(Vertice v1)
        {
            int count = 0;

            this.Vertices.ForEach(v =>
            {
                if (v != v1 && v.IsAdjacente(v1)) count++;
            });

            return count;
        }

        // -> Retorna se um vértice é isolado
        public bool IsIsolado(Vertice v)
        {
            return v.IsIsolado();
        }

        // -> Retorna se um vértice é pendente
        public bool IsPendente(Vertice v)
        {
            return v.IsPendente();
        }

        // -> Retorna se um grafo tem arestas paralela
        public bool HasArestasParalela()
        {
            return this.Vertices.Any(v => v.HasArestasParalela());
        }

        // -> Retorna se um grafo tem loop
        public bool HasLoop()
        {
            return this.Vertices.Any(v => v.HasLoop());
        }

        // -> Retorna se um grafo tem ciclo
        public bool HasCiclo()
        {
            if (this.HasLoop() && this.IsConexo()) return false;

            BuscaProfundidade buscaProfundidade = new BuscaProfundidade();
            buscaProfundidade.Buscar(this);
            return this.Vertices.Any(v => v.ListaAdjacencia.Any(a => a.TipoAresta == "Retorno"));
        }

        // -> Retorna se um grafo é regular
        public bool IsRegular()
        {
            Vertice auxVertice = this.Vertices[0];
            // -> se não existir nenhum vértice com grau diferente do auxiliar return true
            return !this.Vertices.Any(v => v.GetGrau() != auxVertice.GetGrau());
        }

        // -> Retorna se um grafo é nulo
        public bool IsNulo()
        {
            // -> se não achar nenhum vértice que não seja isolado return true
            return !this.Vertices.Any(v => !this.IsIsolado(v));
        }

        // -> Retorna se um grafo é completo
        public bool IsCompleto()
        {
            int auxGrau = this.Vertices[0].GetGrau();
            return (this.IsRegular() && !this.HasArestasParalela() && !this.HasLoop() && (auxGrau == Vertices.Count - 1));
        }

        // -> Retorna se um grafo é conexo
        public bool IsConexo()
        {
            BuscaProfundidade buscaProfundidade = new BuscaProfundidade();
            return buscaProfundidade.Buscar(this) == 1;
        }

        // -> Retorna se um grafo é euleriano
        public bool IsEuleriano()
        {
            return !this.Vertices.Any(v => v.GetGrau() % 2 != 0);
        }

        // -> Retorna se um grafo é unicursal
        public bool IsUnicursal()
        {
            return this.Vertices.FindAll(v => v.GetGrau() % 2 != 0).Count == 2;
        }

        // -> Obtem a quantidade de vértices de um grafo
        public int GetQuantidadeVertices()
        {
            return this.Vertices.Count;
        }

        // -> Obtem o vértice de maior grau
        public Vertice GetVerticeMaiorGrau()
        {
            // -> Ordena a lista de vertice pelos graus de forma descrescente e retorna o primeiro
            return this.Vertices.OrderByDescending(v => this.GetGrau(v)).ToList()[0];
        }

        // -> Obtem os pessos de arestas dos vértices v1 e v2
        public int[] GetPesos(Vertice v1, Vertice v2)
        {
            return v1.GetPesos(v2);
        }

        // -> Retorna uma lista de cut-vertices para o grafo this
        public List<Vertice> GetCutVertices()
        {
            List<Vertice> cutVertices = new List<Vertice>();

            this.Vertices.ForEach(v =>
            {
                Grafo auxGrafo = Grafo.CriarGrafo(this.ArquivoGerador);
                Vertice auxVertice = auxGrafo.GetVertice(v.Id);

                auxGrafo.RemoverVertice(auxVertice);

                if (!auxGrafo.IsConexo()) cutVertices.Add(v);
            });

            return cutVertices;
        }

        // -> Imrpime a árvore geradora mínima usando o algoritmo de Prim
        public void GetAGMPrim(Vertice v)
        {
            this.ResetVerticesChefe();

            Prim prim = new Prim();

            if (this.IsConexo()) prim.GetAGM(this, v);
            else
            {
                System.Console.WriteLine("Esse grafo é desconexo, portanto não é possível gerar sua AGM");
            }
        }

        // -> Imrpime a árvore geradora mínima usando o algoritmo de Kruskal
        public void GetAGMKruskal(Vertice v)
        {
            this.ResetVerticesChefe();

            Kruskal kruskal = new Kruskal();

            if (this.IsConexo()) kruskal.GetAGM(this, v);
            else
            {
                System.Console.WriteLine("Esse grafo é desconexo, portanto não é possível gerar sua AGM");
            }
        }

        // -> Reseta todas as cores dos vértices para o DFS
        public void ResetCoresVertices()
        {
            this.Vertices.ForEach(v => v.SetCorBranco());
        }

        // -> Reseta todos os tempos dos vértices para o DFS
        public void ResetTemposVertices()
        {
            this.Vertices.ForEach(v => v.ResetTempos());
        }

        // -> Reseta todas as classificações de arestas para o DFS
        public void ResetTipoArestas()
        {
            this.Vertices.ForEach(v => v.ListaAdjacencia.ForEach(a => a.ResetAresta()));
        }

        // -> Reseta todos os chefes dos vértice para Prim e Kruskal
        public void ResetVerticesChefe()
        {
            this.Vertices.ForEach(v => v.Chefe = v);
        }

        // -> Ordena os vértice de acordo com o formado dos Ids dos vértices
        public void OrdernarVertices()
        {
            int aux;

            if (int.TryParse(this.Vertices[0].Id, out aux))
            {
                this.Vertices.Sort((v1, v2) => int.Parse(v1.Id) - int.Parse(v2.Id));
            }
            else
            {
                this.Vertices.Sort((v1, v2) => v1.Id.CompareTo(v2.Id));
            }

            this.Vertices.ForEach(v => v.OrdenarAdjacentes());
        }

        // -> Imprime todos os vértices de um grafo
        public void ImprimirVertices()
        {
            // -> Lista todos os vértices e seus respectivos graus
            this.Vertices.ForEach(v => System.Console.WriteLine(v.Id + ": " + this.GetGrau(v)));
        }

        // -> Imprime um grafo com todas suas arestas
        public void ImprimirGrafo()
        {
            this.Vertices.ForEach(v => Console.Write(v));
        }

        // -> Imprime uma matriz de adjacência
        public void ImprimirMatrizAdjacencia()
        {
            Vertices.ForEach(v1 =>
            {
                Vertices.ForEach(v2 =>
                {
                    String aux = String.Join(",", this.GetPesos(v1, v2));
                    aux = (aux == "") ? "0" : aux;
                    Console.Write((v1.IsAdjacente(v2) ? 1 : 0) + ", ");
                });
                Console.WriteLine();
            });
        }

        public void ImprimirMatrizPeso()
        {
            Vertices.ForEach(v1 =>
            {
                Vertices.ForEach(v2 =>
                {
                    String aux = String.Join(",", this.GetPesos(v1, v2));
                    aux = (aux == "") ? "0" : aux;
                    Console.Write("[" + aux + "] ");
                });
                Console.WriteLine();
            });
        }
    }
}
