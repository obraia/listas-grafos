using System;
using System.Collections.Generic;

namespace grafo
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();

            string[] linhas = {
                "1;2;4",
                "2;1;4",
                "1;2;11",
                "1;3;7",
                "15;2;10"
             };

            for (int i = 0; i < linhas.Length; i++)
            {
                string[] aux = linhas[i].Split(';');

                Vertice v1 = new Vertice(aux[0]);
                Vertice v2 = new Vertice(aux[1]);
                int peso = int.Parse(aux[2]);

                if(aux.Length == 3) {
                    grafo.InserirAresta(v1, v2, peso);
                    grafo.InserirAresta(v2, v1, peso);        
                }
                else if (aux[3] == "1") grafo.InserirAresta(v1, v2, peso);
                else grafo.InserirAresta(v2, v1, peso);

                Aresta.Count++;
            }

            grafo.ImprimirGrafo();
            Vertice verticeA = grafo.GetVertice("15");
           
            Console.WriteLine(verticeA.GetGrau());
            Console.WriteLine(grafo.GetGrau(verticeA));

            Console.WriteLine(grafo.getQuantidadeVertices());

            // Vertice v3 = grafo.GetVertice("1");
            // Console.WriteLine(v3);
        }
    }
}
