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
            string nomeArquivo = "EntradaOriginalEmOrdem.txt";
            string[] linhas = File.ReadLines("./files/" + nomeArquivo).ToArray();

            // string[] linhas = {
            //     "Introduçao a Pesquisa;Josiane;1",
            //     "Introduçao a Pesquisa;Josiane;1",
            //     "Grafos;Josiane;2",
            //     "Redes;Leonardo;2",
            //     "Engenharia de Requisitos;Leonardo;3",
            //     "Politicas;Reginaldo;1",
            //     "POO;Reginaldo;2",
            //     "BD;Wagner;1",
            //     "ATP;Wagner;3",
            // };

            Grafo grafo = new Grafo();
            List<Professor> professores = new List<Professor>();

            linhas.ToList().ForEach(l =>
            {
                string[] aux = l.Split(';');
                professores.Add(new Professor(aux[1], aux[0], aux[2]));
            });

            professores.ForEach(p1 =>
            {
                // -> Retorna uma lista com todos os vértices de mesma disciplina e período de p1
                var grupoP1 = professores.FindAll(p2 => p2.Nome == p1.Nome || p2.Periodo == p1.Periodo);

                // -> Percorre a lista criando as arestas no grafo
                grupoP1.ForEach(p3 =>
                {
                    if (p3 != p1) grafo.InserirAresta(p1, p3);
                });
            });

            ObterColoracao(grafo, (Professor)grafo.GetProfessor("1"));

            grafo.OrdernarProfessores();

            grafo.Professores.ForEach(p =>
            {
                Console.ForegroundColor = Grafo.ValorCor(p.Cor.Nome);
                Console.WriteLine(p.Periodo + ": " + p.Disciplina + " - " + p.Nome + " - " + p.Cor);
            });


            Console.ResetColor();

            grafo.Professores.ForEach(p => {
                if(p.Cor is null) throw new Exception("AAAAAAAAAAAAAAAAAA");
            });

            // System.Console.WriteLine();
            // grafo.ImprimirMatrizAdjacencia();
            System.Console.WriteLine();
            int quantidadeCores = grafo.Professores.GroupBy(p => p.Cor).ToList().Count;
            Console.WriteLine("Quantidade de cores: " + quantidadeCores);
        }

        public static void ObterColoracao(Grafo grafo, Professor professor)
        {
            grafo.Professores.ForEach(p => Visitar(p));
        }

        public static void Visitar(Professor professor)
        {
            int contCor = 0;

            while (contCor < Cor.Cores.Length)
            {
                bool hasCor = professor.ListaAdjacencia.Any(a =>
                {
                    if(professor.Disciplina == "ALGORITMOS E ESTRUTURAS DE DADOS") {
                        System.Console.WriteLine();
                    }
                    
                    if (professor.Disciplina == a.Professor.Disciplina && !(a.Professor.Cor is null) && a.Professor.Cor.Horario == "19:00 - 20:40")
                    {
                        contCor += 2;
                    }
                    return a.Professor.Cor == Cor.Cores[contCor];
                });

                if (!hasCor)
                {
                    professor.SetCor(Cor.Cores[contCor]);
                    break;
                }
                else contCor++;
            }
        }
    }
}