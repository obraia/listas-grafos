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
            // -> DESCOMENTE A CHAMADA PARA TESTAR

            RelatorioDirecionado();
            RelatorioNaoDirecionado();
        }

        public static void RelatorioDirecionado()
        {
            string nomeArquivo = "Dirigido1.txt";
            string[] linhas = File.ReadLines("./files/ArquivosDirigidos/" + nomeArquivo).ToArray();

            Grafo grafo = Grafo.CriarGrafo(linhas);

            Vertice v1 = grafo.GetVertice("1");
            Vertice v2 = grafo.GetVertice("2");

            Console.WriteLine("O vértice {0} tem grau de entrada: {1}", v1.Id, grafo.GetGrauEntrada(v1));
            Console.WriteLine("O vértice {0} tem grau de saída: {1}", v1.Id, grafo.GetGrau(v2));
            Console.WriteLine("O grafo possui ciclo: " + grafo.HasCiclo());
        }

        public static void RelatorioNaoDirecionado()
        {
            string nomeArquivo = "completo3.txt";
            string[] linhas = File.ReadLines("./files/ArquivosNaoDirigidos/" + nomeArquivo).ToArray();

            Grafo grafo = Grafo.CriarGrafo(linhas);

            Grafo grafoP = Grafo.CriarGrafo(linhas);
            Grafo grafoK = Grafo.CriarGrafo(linhas);

            Vertice v1 = grafo.GetVertice("1");
            Vertice v2 = grafo.GetVertice("2");

            Vertice vk = grafoP.GetVertice("1");
            Vertice vp = grafoK.GetVertice("1");

            // -> PARA GRAFOS NÃO DIRECIONADO

            Console.WriteLine("{0} e {1} são adjacente: {2}", v1.Id, v2.Id, grafo.IsAdjacente(v1, v2));
            Console.WriteLine("O vértice {0} tem grau: {1}", v1.Id, grafo.GetGrau(v1));
            Console.WriteLine("O vértice {0} é isolado: {1}", v1.Id, grafo.IsIsolado(v1));
            Console.WriteLine("O vértice {0} é pendente: {1}", v1.Id, grafo.IsPendente(v1));

            Console.WriteLine("O grafo é regular: " + grafo.IsRegular());
            Console.WriteLine("O grafo é nulo: " + grafo.IsNulo());
            Console.WriteLine("O grafo é completo: " + grafo.IsCompleto());
            Console.WriteLine("O grafo é conexo: " + grafo.IsConexo());
            Console.WriteLine("O grafo é euleriano: " + grafo.IsEuleriano());
            Console.WriteLine("O grafo é unicursal: " + grafo.IsUnicursal());

            Console.WriteLine("A quantidade de cut-vértices é: " + grafo.GetCutVertices().Count);
            grafo.GetCutVertices().ForEach(v => Console.WriteLine(v.Id));

            grafoP.GetAGMPrim(vp);
            System.Console.WriteLine();
            System.Console.WriteLine();
            grafoK.GetAGMKruskal(vk);
        }


    }
}
