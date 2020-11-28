using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace grafo
{
    public class Grafo
    {
        public List<Professor> Professores = new List<Professor>();
        public string[] ArquivoGerador;

        // -> Contrutor, inicia contador da aresta com 1
        public Grafo()
        {
            Aresta.IdCount = 1;
        }

        // -> Insere um vértice na lista de vértices do grafo
        public void InserirProfessor(Professor p)
        {
            if (!(p is null)) this.Professores.Add(p);
        }

        // -> Remove um vértice totalmente de um grafo
        public void RemoverProfessor(Professor p)
        {
            // -> remove v da lista de vértices e em todos que tem como adjacente
            if (!(p is null))
            {
                this.Professores.Remove(p);
                this.Professores.ForEach(p1 => p1.RemoverAdjacente(p));
            }
        }

        // -> Insere ua aresta composta por dois vértices e o peso
        public void InserirAresta(Professor de, Professor para)
        {
            // -> busca se os vértices já estão presentes no grafo
            Professor auxDe = this.Professores.Find(v => v.Id == de.Id);

            if (auxDe is null)
            {
                this.InserirProfessor(de);
                auxDe = de;
            }

            // -> busca se os vértices já estão presentes no grafo
            Professor auxPara = this.Professores.Find(v => v.Id == para.Id);

            if (auxPara is null)
            {
                this.InserirProfessor(para);
                auxPara = para;
            }

            auxDe.AdicionarAdjacente(auxPara);
        }

        // -> Retorna um vértice a partir do seu id
        public Professor GetProfessor(string id)
        {
            return this.Professores.Find(p => p.Id == id);
        }

        // -> Verifica se há adjacência entr dois vértices
        public bool IsAdjacente(Professor p1, Professor p2)
        {
            return p1.IsAdjacente(p2);
        }

        // -> Ordena os vértice de acordo com o formado dos Ids dos vértices
        public void OrdernarProfessores()
        {
            this.Professores = this.Professores.OrderBy(p => p.Periodo)
            .ThenBy(p => ValorDia(p.Cor.Dia)).ThenBy(p => ValorHora(p.Cor.Horario)).ToList();
        }

        public static int ValorDia(string dia)
        {
            switch (dia)
            {
                case "Segunda-feira": return 1;
                case "Terça-feira": return 2;
                case "Quarta-feira": return 3;
                case "Quinta-feira": return 4;
                case "Sexta-feira": return 5;
                case "Sábado-feira": return 6;
                default: return -1;
            }
        }

        public static int ValorHora(string hora)
        {
            return int.Parse(hora.Substring(0, 2));
        }

        public static ConsoleColor ValorCor(string cor)
        {
            switch (cor)
            {
                case "Amarelo": return ConsoleColor.DarkYellow;
                case "Azul": return ConsoleColor.Blue;
                case "Branco": return ConsoleColor.White;
                case "Cinza": return ConsoleColor.DarkGray;
                case "Magenta": return ConsoleColor.Magenta;
                case "Ciano": return ConsoleColor.Cyan;
                case "Verde-escuro": return ConsoleColor.DarkGreen;
                case "Vinho": return ConsoleColor.DarkRed;
                case "Verde": return ConsoleColor.Green;
                case "Vermelho": return ConsoleColor.Red;
                case "Roxo": return ConsoleColor.DarkMagenta;
                default: return ConsoleColor.White;
            }
        }

        // -> Imprime um grafo com todas suas arestas
        public void ImprimirGrafo()
        {
            this.Professores.ForEach(p => Console.Write(p));
        }

        // -> Imprime uma matriz de adjacência
        public void ImprimirMatrizAdjacencia()
        {
            string matriz = "";

            Professores.ForEach(p1 =>
            {
                Professores.ForEach(p2 =>
                {
                    Console.Write((p1.IsAdjacente(p2) ? 1 : 0) + ", ");
                    matriz += (p1.IsAdjacente(p2) ? 1 : 0) + ", ";
                });
                Console.WriteLine("");
                matriz += "\n";
            });

            File.WriteAllText("matriz.txt", matriz, Encoding.UTF8);
        }
    }
}
