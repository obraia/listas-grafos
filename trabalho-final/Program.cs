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
            string[] linhas = {
                "Introduçao a Pesquisa;Josiane;1",
                "Introduçao a Pesquisa;Josiane;1",
                "Grafos;Josiane;2",
                "Redes;Leonardo;2",
                "Engenharia de Requisitos;Leonardo;3",
                "Politicas;Reginaldo;1",
                "POO;Reginaldo;2",
                "BD;Wagner;1",
                "ATP;Wagner;3",
            };

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
                    if (p3 != p1) grafo.InserirAresta(p1, p3, 0);
                });
            });

            grafo.ImprimirMatrizAdjacencia();
        }
    }
}