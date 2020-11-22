using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    class ArestaK {
        public int Id;
        public Vertice V1;
        public int Peso;
        public Vertice V2;

        public ArestaK(Vertice v1, Vertice v2, int peso, int id) {
            
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

    class Kruskal
    {
        public ArestaK GetAGM(Grafo grafo, Vertice v1)
        {
            List<ArestaK> arestasK = new List<ArestaK>();
            Grafo grafoAGM = new Grafo();

            int pesoMinimo = v1.ListaAdjacencia.Min(a => a.Peso);
            Aresta adjV1Minimo = v1.ListaAdjacencia.Find(a => a.Peso == pesoMinimo);

            ArestaK arestaInicial = new ArestaK(v1, adjV1Minimo.Vertice, adjV1Minimo.Peso, adjV1Minimo.Id);
            
            // -> Adicionando primeira aresta
            // arestasK.Add(new ArestaK(v1, adjV1Minimo.Vertice, adjV1Minimo.Peso, adjV1Minimo.Id));

            // -> Agrupando todas as arestas do grafo
            grafo.Vertices.ForEach(v => {
                v.ListaAdjacencia.ForEach(a => {
                    // -> Não adiciona arestas de mesmo Id
                    if(!arestasK.Any(a1 => a1.Id == a.Id)) {
                        arestasK.Add(new ArestaK(v, a.Vertice, a.Peso, a.Id));
                    }
                });
            });

            arestasK.Sort((a1, a2) => a1.Peso - a2.Peso);

            arestasK.RemoveAll(a => a.Id == arestaInicial.Id);
            arestasK.Insert(0, arestaInicial);
            
            arestasK.ForEach(a => {


                if (grafo.GetQuantidadeVertices() != Aresta.IdCount)
                {
                    if(a.V1.Chefe.Id != a.V2.Chefe.Id) {

                        if (a.V2.Chefe != a.V2)
                        {
                            a.V1.Chefe = a.V2.Chefe;
                        }
                        else
                        {
                            a.V2.Chefe = a.V1.Chefe;
                        }

                        System.Console.WriteLine(a);
                        System.Console.WriteLine();

                        grafoAGM.InserirAresta(a.V1, a.V2, a.Peso);
                        grafoAGM.InserirAresta(a.V2, a.V1, a.Peso);

                        Aresta.IdCount++;
                    }
                }       
            });

            // grafoAGM.ImprimirGrafo();
            // grafoAGM.ImprimirMatrizAdjacencia();
            // System.Console.WriteLine(grafoAGM.HasCiclo());
            // System.Console.WriteLine();
            // grafoAGM.ImprimirMatrizAdjacencia();

            return null;
        }

        public void Visitar(Vertice v)
        {
            
        }
    }
}