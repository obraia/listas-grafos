using System;
using System.Collections.Generic;

namespace grafo {

    class Program {
        
        static void Main(string[] args) {
            Grafo grafo = new Grafo();

            string[] linhas = {
                "v7;v1;10",

                "v1;v2;10",
                "v1;v3;10",
                "v1;v4;10",
                "v1;v5;10",
                "v2;v3;10",
                "v2;v4;10",
                "v2;v5;10",
                "v3;v4;10",
                "v3;v5;10",
                "v4;v5;10",

                // "v6;v12;10",

                // "v8;v9;10",
                // "v9;v10;10",
                // "v10;v11;10",
             };

            for (int i = 0; i < linhas.Length; i++) {
                string[] aux = linhas[i].Split(';');

                Vertice v1 = new Vertice(aux[0]);

                // -> Tratar vértices isolados
                if(aux.Length > 1) {
                    Vertice v2 = new Vertice(aux[1]);
                    int peso = int.Parse(aux[2]);

                    if (aux.Length == 3) {
                        grafo.InserirAresta(v1, v2, peso);
                        // -> Tratar arestas paralelas, caso tiver os mesmo id não adicona a segunda aresta
                        if (v1.Id != v2.Id) grafo.InserirAresta(v2, v1, peso);
                    } 
                    else if (aux[3] == "1") grafo.InserirAresta(v1, v2, peso);
                    else grafo.InserirAresta(v2, v1, peso);

                    Aresta.IdCount++;
                } 
                else grafo.InserirVertice(v1);
            }

            grafo.ordernarVertices("a ->");

            // grafo.imprimirVertices();

            // grafo.ImprimirMatriz();
            // Console.WriteLine();
            
            // grafo.ImprimirGrafo();
            // Console.WriteLine();

            // Console.WriteLine("Quantidade total de vértices:" + grafo.getQuantidadeVertices());
            // Console.WriteLine("O grafo é completo: " + (grafo.IsCompleto() ? "Sim" : "Não"));

            // System.Console.WriteLine(grafo.GetVertice("v2"));
            // System.Console.WriteLine(grafo.GetVertice("v1"));
            // System.Console.WriteLine(grafo.GetVertice("v3"));

            System.Console.WriteLine(grafo.IsConexo()); 
        }
    }
}
