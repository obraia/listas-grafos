using System;
using System.Collections.Generic;

namespace grafo
{
    public class Aresta
    {
        public static int Count = 1;
        public int Id { get; private set; }
        private Vertice Vertice;
        private int Peso;

        public Aresta(Vertice vertice, int peso)
        {
            this.Id = Count;
            this.Vertice = vertice;
            this.Peso = peso;
        }

        public string getVerticeId() {
            return Vertice.Id;
        }

        public override string ToString()
        {
            return this.Vertice.Id + " : " + this.Peso;
        }
    }
}
