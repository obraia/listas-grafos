using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    class Grafo
    {
        private List<Vertice> Vertices = new List<Vertice>();

        public Grafo() {
            Aresta.Count = 0;
        }
        
        public void InserirAresta(Vertice de, Vertice para, int peso)
        {
            // -> busca se os vértices já estão presentes no grafo
            Vertice auxDe = this.Vertices.Find(v => v.Id == de.Id);
            Vertice auxPara = this.Vertices.Find(v => v.Id == para.Id);

            // -> se o vertice de partida nao estiver presente no grafo
            if (auxDe is null)
            {
                de.AdicionarAdjacente(para, peso);
                this.Vertices.Add(de);
            }
            else
            {
                auxDe.AdicionarAdjacente(para, peso);
            }

            // -> se o vertice de destino nao estiver presente no grafo
            if (auxPara is null)
            {
                this.Vertices.Add(para);
            }
        }

        public Vertice GetVertice(string id)
        {
            return this.Vertices.Find(v => v.Id == id);
        }

        public bool IsAdjacente(Vertice v1, Vertice v2)
        {
            return v1.IsAdjacente(v2);
        }

        public int GetGrau(Vertice v1)
        {
            return v1.GetGrau();
        }

        public bool IsIsolado(Vertice v1)
        {
            return v1.IsIsolado();
        }

        public bool IsPendente(Vertice v1)
        {
            return v1.IsPendente();
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
            return !this.Vertices.Any(v => !v.IsIsolado());
        }

        public bool IsCompleto()
        {
            return false;
        }

        public bool IsConexo()
        {
            return false;
        }

        public bool IsEuleriano()
        {
            return false;
        }

        public bool IsUnicursal()
        {
            return false;
        }

        public int getQuantidadeVertices()
        {
            return this.Vertices.Count;
        }

        public string listarVertices()
        {
            string vertices = "";
            this.Vertices.ForEach(v => vertices += v.Id + " ");

            return vertices;
        }

        public void ImprimirGrafo()
        {
            foreach (var v in Vertices)
            {
                Console.Write(v);
            }
        }
    }
}
