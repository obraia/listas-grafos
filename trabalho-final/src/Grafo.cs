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

        public static Grafo CriarGrafo(string[] linhas)
        {
            Grafo grafo = new Grafo();
            List<Professor> professores = new List<Professor>();

            linhas.ToList().ForEach(l =>
            {
                string[] aux = l.Split(' ');
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

            return grafo;
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

        // -> Faz comparações e insere um professor no grafo
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

        // -> Método que visita cada vértice para fazer sua coloração coloração
        public void ObterColoracao(Professor professor)
        {
            if (!(professor is null))
            {
                this.Professores.Remove(professor);
                this.Professores.Insert(0, professor);
                this.Professores.ForEach(p => this.Colorir(p));
            }
            else
            {
                Console.WriteLine("Professor não encontrado");
            }
        }

        // -> Método que comparar cada vértices adjacentes e define sua coloração
        private void Colorir(Professor professor)
        {
            int contCor = 0;

            while (contCor < Cor.Cores.Length)
            {
                bool hasCor = professor.ListaAdjacencia.Any(a =>
                {
                    if ((professor.Disciplina == a.Professor.Disciplina) && a.Professor.Cor.Horario == "19:00 - 20:40")
                    {
                        contCor += 2;
                    }
                    return a.Professor.Cor == Cor.Cores[contCor];
                });

                hasCor = professor.ListaAdjacencia.Any(a => a.Professor.Cor == Cor.Cores[contCor]);

                if (!hasCor)
                {
                    professor.SetCor(Cor.Cores[contCor]);
                    break;
                }
                else contCor++;
            }
        }

        // -> Retorna a quantidade de cores apos a colocação, e -1 caso não tenha sido classificado
        public int ObterQuantidadeCores()
        {
            if (this.Professores[0].Cor.Nome == "") return -1;
            return this.Professores.GroupBy(p => p.Cor).ToList().Count;
        }

        // -> Ordena os vértice de acordo com o formado dos Ids dos vértices
        public void OrdernarProfessores()
        {
            this.Professores = this.Professores.OrderBy(p => p.Periodo)
            .ThenBy(p => Cor.ValorDia(p.Cor.Dia)).ThenBy(p => Cor.ValorHora(p.Cor.Horario)).ToList();
        }

        public void OrdernarProfessoresCores()
        {
            this.Professores = this.Professores.OrderBy(p => p.Cor.Nome)
            .ThenBy(p => p.Periodo).ThenBy(p => Cor.ValorHora(p.Cor.Horario)).ToList();
        }

        // -> Imprime um grafo com todas suas arestas
        public void ImprimirGrafo()
        {
            this.Professores.ForEach(p => Console.Write(p));
        }

        // -> Listar professor, disciplinas e periodos com seus dias e horários
        public void ListarProfessor()
        {
            this.Professores.ForEach(p =>
            {
                Console.ForegroundColor = Cor.ValorCor(p.Cor.Nome);
                Console.WriteLine(p.Periodo + ": " + p.Disciplina + " - " + p.Nome + " - " + p.Cor);
            });

            Console.ResetColor();
        }

        // -> Imprime um tabela de acordo com as coloações
        public void ImprimirTabela()
        {
            IPrintTabularData<Professor> professorDataPrinter = new TablePrinter<Professor>();
            professorDataPrinter.PrintTable(this.Professores);
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
