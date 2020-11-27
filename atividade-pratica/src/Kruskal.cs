using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    class Kruskal
    {
        // -> Retorna Arvore Geradora Mínima usando o algoritmo de Kruskal
        public ArestaK GetAGM(Grafo grafo, Vertice v1)
        {
            List<ArestaK> arestasK = new List<ArestaK>();
            Grafo grafoAGM = new Grafo();

            int pesoMinimo = v1.ListaAdjacencia.Min(a => a.Peso);
            Aresta adjV1Minimo = v1.ListaAdjacencia.Find(a => a.Peso == pesoMinimo);

            ArestaK arestaInicial = new ArestaK(v1, adjV1Minimo.Vertice, adjV1Minimo.Peso, adjV1Minimo.Id);


            // -> Agrupando todas as arestas do grafo
            grafo.Vertices.ForEach(v =>
            {
                v.ListaAdjacencia.ForEach(a =>
                {
                    // -> Não adiciona arestas de mesmo Id
                    if (!arestasK.Any(a1 => a1.Id == a.Id))
                    {
                        arestasK.Add(new ArestaK(v, a.Vertice, a.Peso, a.Id));
                    }
                });
            });

            // -> Ordena elementos a partir do peso
            arestasK.Sort((a1, a2) => a1.Peso - a2.Peso);

            arestasK.RemoveAll(a => a.Id == arestaInicial.Id);
            arestasK.Insert(0, arestaInicial);

            arestasK.ForEach(a =>
            {
                if (grafo.GetQuantidadeVertices() != Aresta.IdCount)
                {

                    if (a.V1.Chefe.Id != a.V2.Chefe.Id)
                    {

                        if (a.V2.Chefe != a.V2)
                        {
                            a.V1.Chefe = a.V2.Chefe;
                        }
                        else
                        {
                            a.V2.Chefe = a.V1.Chefe;
                        }

                        System.Console.WriteLine(a);

                        grafoAGM.InserirAresta(a.V1, a.V2, a.Peso);
                        grafoAGM.InserirAresta(a.V2, a.V1, a.Peso);

                        Aresta.IdCount++;
                    }
                }
            });

            return null;
        }
    }
}