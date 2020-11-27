using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    public class Professor: Vertice
    {
        public static int CuntId = 1;
        public string Nome { get; set; }
        public string Disciplina { get; set; }
        public int Periodo { get; set; }
        public new Cor Cor { get; private set; }

        // -> Contrutor, constroi uma classe
        public Professor(string nome, string disciplina, string periodo)
        {
            this.Id = CuntId.ToString();
            this.Nome = nome;
            this.Disciplina = disciplina;
            this.Periodo = int.Parse(periodo);

            CuntId++;
        }

        public override string ToString()
        {
            string ligacoes = "";
            this.ListaAdjacencia.ForEach(a => ligacoes += "[" + a.Id + "] " + this.Nome + " -> " + a + "\n");
            return (ligacoes != "") ? ligacoes : "[null] " + this.Nome + "\n";
        }
    }
}
