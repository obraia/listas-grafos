using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using Spire.Xls;

namespace grafo
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoArquivo = "arquivo.txt";
            string[] linhas = File.ReadLines("./arquivos/" + caminhoArquivo).ToArray();

            // string[] linhas = {
            //     "Introduçao_a_Pesquisa Paulo 4",
            //     "Introduçao_a_Pesquisa Paulo 4",
            //     "Grafos Michelle 4",
            //     "Redes Michelle 4",
            //     "Engenharia_de_Requisitos Michelle 4",
            //     "Politicas Adriano 4",
            //     "POO Paulo 2",
            //     "BD Claudiney 4",
            //     "ATP Faber 1",
            // };

            Grafo grafo = Grafo.CriarGrafo(linhas);

            // -> Irá iniciar com o primeiro vértice lido do arquivo
            grafo.ObterColoracao(grafo.GetProfessor("1"));

            System.Console.WriteLine("\nOrdenação por cores\n");
            grafo.OrdernarProfessoresCores();
            grafo.ListarProfessor();

            System.Console.WriteLine("\nOrdenação por perídos\n");
            grafo.OrdernarProfessores();
            grafo.ListarProfessor();

            System.Console.WriteLine();

            grafo.ImprimirTabela();
            System.Console.WriteLine();

            Console.WriteLine("Quantidade de de horários necessários para alocar todas as disciplinas: " + grafo.ObterQuantidadeCores());

            Console.ReadLine();
        }
    }
}