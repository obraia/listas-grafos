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

        public Aresta(Vertice vertice, int peso) {
            this.Id = IdCount;
            this.Vertice = vertice;
            this.Peso = peso;
        }

        public string getVerticeId() {
            return Vertice.Id;
        }

        public override string ToString() {
            return this.Vertice.Id + " : " + this.Peso;
        }
    }
}
