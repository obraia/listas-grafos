using System;
using System.Collections.Generic;

namespace grafo
{
    public class Ligacao
    {
        private Vertice Vertice;
        private int Peso;

        public Ligacao(Vertice vertice, int peso)
        {
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
