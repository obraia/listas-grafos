using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    class Prim
    {
        // -> Retorna Arvore Geradora Mínima usando o algoritmo de Prim
        public void GetAGM(Grafo grafo, Vertice v1)
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


            // -> Inserir aresta inicial
            grafoAGM.InserirAresta(arestaInicial.V1, arestaInicial.V2, arestaInicial.Peso);
            Aresta.IdCount++;

            while (grafoAGM.Vertices.Count != grafo.Vertices.Count)
            {
                List<ArestaK> menorPesos = new List<ArestaK>();

                grafoAGM.Vertices.ForEach(v =>
                {
                    ArestaK aux = arestasK.Find(a => a.V1.Id == v.Id || a.V2.Id == v.Id);
                    
                    if(!(aux is null)) menorPesos.Add(aux);
                });

                menorPesos.Sort((a1, a2) => a1.Peso - a2.Peso);

                ArestaK auxAresta = menorPesos[0];

                if (auxAresta.V1.Chefe.Id != auxAresta.V2.Chefe.Id)
                {
                    if (auxAresta.V2.Chefe != auxAresta.V2)
                    {
                        auxAresta.V1.Chefe = auxAresta.V2.Chefe;
                    }
                    else
                    {
                        auxAresta.V2.Chefe = auxAresta.V1.Chefe;
                    }

                    System.Console.WriteLine(auxAresta);

                    grafoAGM.InserirAresta(auxAresta.V1, auxAresta.V2, auxAresta.Peso);
                    grafoAGM.InserirAresta(auxAresta.V2, auxAresta.V1, auxAresta.Peso);

                    Aresta.IdCount++;
                }

                arestasK.Remove(auxAresta);
            }
        }
    }
}