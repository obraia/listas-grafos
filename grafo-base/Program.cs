using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace grafo
{
    
    class Program
    {

        static void Main(string[] args)
        {

            string[] linhas =  File.ReadLines("./files/ArquivosNaoDirigidos/completo3.txt").ToArray();

            // string[] linhas = {

            //     // "a;b;10;1",
            //     // "a;c;10;1",
            //     // "a;d;10;1",
            //     // "c;b;10;1",
            //     // "c;d;10;1",
            //     // "e;d;10;1",

            //     // "2;4;60",
            //     // "2;5;70",
            //     // "3;4;80",
            //     // "3;5;90",
            //     // "1;2;10",
            //     // "1;3;20",
            //     // "1;4;30",
            //     // "1;5;40",
            //     // "2;3;50",

            //     // "3;2;10",
            //     // "3;4;10",
            //     // "3;1;10",
            //     // "1;5;10",

            //     // "a;d;6",
            //     // "d;b;15",
            //     // "d;e;6",
            //     // "b;c;3",
            //     // "b;e;1",
            //     // "e;c;2",

            //     "a;b;9",
            //     "a;d;6",
            //     "b;c;8",
            //     "b;d;15",
            //     "d;e;6",
            //     "d;f;11",
            //     "b;e;5",
            //     "e;c;6",
            //     "e;g;7",
            //     "d;g;8",
            //     "f;g;8",

            // };

            Grafo grafo = Grafo.CriarGrafo(linhas);
            Grafo grafo2 = Grafo.CriarGrafo(linhas);

            grafo.GetAGMKruskal(grafo.GetVertice("1"));
            System.Console.WriteLine();
            grafo.GetAGMPrim(grafo2.GetVertice("1"));

            grafo.ImprimirMatrizAdjacencia();

            

        }
    }
}
