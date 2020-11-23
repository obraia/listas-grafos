using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    class ArestaK
    {
        public int Id;
        public Vertice V1;
        public int Peso;
        public Vertice V2;

        public ArestaK(Vertice v1, Vertice v2, int peso, int id)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.Peso = peso;
            this.Id = id;
        }

        public override string ToString()
        {
            return this.Id + ": " + this.V1.Id + " <--> " + this.V2.Id + " : " + this.Peso;
        }
    }

}