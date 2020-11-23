using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{

    public class Grafo
    {
        public List<Vertice> Vertices = new List<Vertice>();
        public string[] ArquivoGerador;

        public static Grafo CriarGrafo(string[] linhas)
        {
            Grafo grafo = new Grafo();

            for (int i = 0; i < linhas.Length; i++)
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

        public Grafo()
        {
            Aresta.IdCount = 1;
        }

        public void InserirVertice(Vertice v)
        {
            if (!(v is null)) this.Vertices.Add(v);
        }

        public void RemoverVertice(Vertice v)
        {
            // -> remove v da lista de vértices e em todos que tem como adjacente
            if (!(v is null))
            {
                this.Vertices.Remove(v);
                this.Vertices.ForEach(v1 => v1.RemoverAdjacente(v));
            }
        }

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

        public Vertice GetVertice(string id)
        {
            return this.Vertices.Find(v => v.Id == id);
        }

        public bool IsAdjacente(Vertice v1, Vertice v2)
        {
            return v1.IsAdjacente(v2);
        }

        public int GetGrau(Vertice v)
        {
            return v.GetGrau();
        }

        public int GetGrauEntrada(Vertice v1)
        {
            int count = 0;

            this.Vertices.ForEach(v =>
            {
                if (v != v1 && v.IsAdjacente(v1)) count++;
            });

            return count;
        }

        public bool IsIsolado(Vertice v)
        {
            return v.IsIsolado();
        }

        public bool IsPendente(Vertice v)
        {
            return v.IsPendente();
        }

        public bool HasArestasParalela()
        {
            return this.Vertices.Any(v => v.HasArestasParalela());
        }

        public bool HasLoop()
        {
            return this.Vertices.Any(v => v.HasLoop());
        }

        public bool HasCiclo()
        {
            if (this.HasLoop() && this.IsConexo()) return false;

            BuscaProfundidade buscaProfundidade = new BuscaProfundidade();
            buscaProfundidade.Buscar(this);
            return this.Vertices.Any(v => v.ListaAdjacencia.Any(a => a.TipoAresta == "Retorno"));
        }

        public bool IsRegular()
        {
            Vertice auxVertice = this.Vertices[0];
            // -> se não existir nenhum vértice com grau diferente do auxiliar return true
            return !this.Vertices.Any(v => v.GetGrau() != auxVertice.GetGrau());
        }

        public bool IsNulo()
        {
            // -> se não achar nenhum vértice que não seja isolado return true
            return !this.Vertices.Any(v => !this.IsIsolado(v));
        }

        public bool IsCompleto()
        {
            int auxGrau = this.Vertices[0].GetGrau();
            return (this.IsRegular() && !this.HasArestasParalela() && !this.HasLoop() && (auxGrau == Vertices.Count - 1));
        }

        public bool IsConexo()
        {
            BuscaProfundidade buscaProfundidade = new BuscaProfundidade();
            return buscaProfundidade.Buscar(this) == 1;
        }

        public bool IsEuleriano()
        {
            return !this.Vertices.Any(v => v.GetGrau() % 2 != 0);
        }

        public bool IsUnicursal()
        {
            return this.Vertices.FindAll(v => v.GetGrau() % 2 != 0).Count == 2;
        }

        public int GetQuantidadeVertices()
        {
            return this.Vertices.Count;
        }

        public Vertice GetVerticeMaiorGrau()
        {
            // -> Ordena a lista de vertice pelos graus de forma descrescente e retorna o primeiro
            return this.Vertices.OrderByDescending(v => this.GetGrau(v)).ToList()[0];
        }

        public int[] GetPesos(Vertice v1, Vertice v2)
        {
            return v1.GetPesos(v2);
        }

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

        public void ResetCoresVertices()
        {
            this.Vertices.ForEach(v => v.SetCorBranco());
        }

        public void ResetTemposVertices()
        {
            this.Vertices.ForEach(v => v.ResetTempos());
        }

        public void ResetTipoArestas()
        {
            this.Vertices.ForEach(v => v.ListaAdjacencia.ForEach(a => a.ResetAresta()));
        }

        public void ResetVerticesChefe()
        {
            this.Vertices.ForEach(v => v.Chefe = v);
        }

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

        public void ImprimirVertices()
        {
            // -> Lista todos os vértices e seus respectivos graus
            this.Vertices.ForEach(v => System.Console.WriteLine($"{v.Id}: {this.GetGrau(v)}"));
        }

        public void ImprimirGrafo()
        {
            this.Vertices.ForEach(v => Console.Write(v));
        }

        public void ImprimirMatrizAdjacencia()
        {
            Vertices.ForEach(v1 =>
            {
                Vertices.ForEach(v2 =>
                {
                    String aux = String.Join(",", this.GetPesos(v1, v2));
                    aux = (aux == "") ? "0" : aux;
                    Console.Write($"{(v1.IsAdjacente(v2) ? 1 : 0)},");
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
                    Console.Write($"[{aux}] ");
                });
                Console.WriteLine();
            });
        }
    }
}
