using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    class Prim
    {
        public Grafo GetAGM(Grafo grafo, Vertice v1)
        {
            List<Vertice> conjuntoArvore = new List<Vertice>();
            Grafo GrafoAGM = new Grafo();

            GrafoAGM.InserirVertice(new Vertice(v1.Id));

            int pesoMinimo = v1.ListaAdjacencia.Min(a => a.Peso);
            Vertice verticeMinimo = v1.ListaAdjacencia.Find(a => a.Peso == pesoMinimo).Vertice;

            GrafoAGM.Vertices.ForEach(v => {
                
            });

            grafo.Vertices.ForEach(v => {

            });


            v1.ListaAdjacencia.GroupBy(v => v.Peso);


            return null;
        }

        public void Visitar(Vertice v)
        {
            
        }
    }
}