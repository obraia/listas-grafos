using System;
using System.Collections.Generic;

namespace grafo
{
    public class Aresta
    {
        public static int IdCount = 1;
        public int Id { get; private set; }
        public Vertice Vertice { get; private set; }
        public int Peso { get; private set; }
        public string TipoAresta { get; set; }
        public Aresta(Vertice vertice, int peso)
        {
            this.Id = IdCount;
            this.Vertice = vertice;
            this.Peso = peso;
        }

        public void ResetAresta() {
            this.TipoAresta = null;
        }

        public override string ToString()
        {
            return this.Vertice.Id + " : " + this.Peso + " -> " + this.TipoAresta;
        }
    }
}
