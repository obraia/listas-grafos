using System;
using System.Collections.Generic;

namespace grafo
{
    
    class Program
    {

        static void Main(string[] args)
        {

            string[] linhas = {

                // "a;b;10;1",
                // "a;c;10;1",
                // "a;d;10;1",
                // "c;b;10;1",
                // "c;d;10;1",
                // "e;d;10;1",

                // "2;4;60",
                // "2;5;70",
                // "3;4;80",
                // "3;5;90",
                // "1;2;10",
                // "1;3;20",
                // "1;4;30",
                // "1;5;40",
                // "2;3;50",

                // "3;2;10",
                // "3;4;10",
                // "3;1;10",
                // "1;5;10",

                // "a;d;6",
                // "d;b;15",
                // "d;e;6",
                // "b;c;3",
                // "b;e;1",
                // "e;c;2",

                "a;b;9",
                "a;d;6",
                "b;c;8",
                "b;d;15",
                "d;e;6",
                "d;f;11",
                "b;e;5",
                "e;c;6",
                "e;g;7",
                "d;g;8",
                "f;g;8",

            };

            Grafo grafo = Grafo.CriarGrafo(linhas);

            // System.Console.WriteLine(grafo.IsConexo());
            // System.Console.WriteLine(grafo.HasCiclo());

            // grafo.ImprimirGrafo();
            // grafo.GetAGMPrim(grafo.GetVertice("a"));
            System.Console.WriteLine();
            grafo.GetAGMKruskal(grafo.GetVertice("b"));


            // grafo.RemoverVertice(grafo.GetVertice("v1"));

            // grafo.ImprimirVertices();

            // grafo.ImprimirMatriz();
            // Console.WriteLine();

            // grafo.ImprimirGrafo();
            // Console.WriteLine();

            // grafo.GetCutVertices().ForEach(v => Console.WriteLine(v.Id));

            // Vertice v1 = grafo.GetVertice("v1");
            // Vertice v6 = grafo.GetVertice("v6");

            // System.Console.WriteLine(grafo.GetGrau(v1));
            // System.Console.WriteLine(grafo.GetGrauEntrada(v1));
            // System.Console.WriteLine(grafo.GetGrauEntrada(v6));
            // System.Console.WriteLine(grafo.GetGrau(v6));
            // grafo.ImprimirMatrizAdjacencia();

            // grafo.ImprimirGrafo();

            // Console.WriteLine("Quantidade total de vértices:" + grafo.GetQuantidadeVertices());
            // Console.WriteLine("O grafo é completo: " + (grafo.IsCompleto() ? "Sim" : "Não"));

            // System.Console.WriteLine("v1 " + grafo.GetVertice("v1").GetGrau());
            // System.Console.WriteLine("v2 " + grafo.GetVertice("v2").GetGrau());
            // System.Console.WriteLine("v3 " + grafo.GetVertice("v3").GetGrau());
            // System.Console.WriteLine("v4 " + grafo.GetVertice("v4").GetGrau());
            // System.Console.WriteLine("v5 " + grafo.GetVertice("v5").GetGrau());

            // System.Console.WriteLine(grafo.IsEuleriano());
            // System.Console.WriteLine(grafo.IsUnicursal());
        }
    }
}
