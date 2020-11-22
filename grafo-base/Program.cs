using System;
using System.Collections.Generic;

namespace grafo
{

    class Program
    {

        static void Main(string[] args)
        {

            string[] linhas = {
                "v1;v2;10;1",
                "v1;v3;10;-1",
                "v1;v4;10;1",
                "v1;v5;10;-1",

                "v6;v5;10;-1",
                "v6;v4;10;-1",
                "v6;v7;10;1",
                "v6;v8;10;-1",
             };

            Grafo grafo = Grafo.CriarGrafo(linhas);

            grafo.OrdernarVertices("a ->");


            // grafo.RemoverVertice(grafo.GetVertice("v1"));

            // grafo.ImprimirVertices();

            // grafo.ImprimirMatriz();
            // Console.WriteLine();

            // grafo.ImprimirGrafo();
            // Console.WriteLine();

            // grafo.GetCutVertices().ForEach(v => Console.WriteLine(v.Id));

            Vertice v1 = grafo.GetVertice("v1");
            Vertice v6 = grafo.GetVertice("v6");

            System.Console.WriteLine(grafo.GetGrau(v1));
            System.Console.WriteLine(grafo.GetGrauEntrada(v1));
            System.Console.WriteLine(grafo.GetGrauEntrada(v6));
            System.Console.WriteLine(grafo.GetGrau(v6));
            // grafo.ImprimirMatriz();

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
