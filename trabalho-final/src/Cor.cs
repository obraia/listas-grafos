using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{
    public class Cor
    {
        public static Cor[] Cores = {
            new Cor("Amarelo", "19:00 - 20:40", "Segunda-feira"),
            new Cor("Azul", "20:50 - 22:30", "Segunda-feira"),
            new Cor("Branco", "19:00 - 20:40", "Terça-feira"),
            new Cor("Cinza", "20:50 - 22:30", "Terça-feira"),
            new Cor("Laranja", "19:00 - 20:40", "Quarta-feira"),
            new Cor("Marrom", "20:50 - 22:30", "Quarta-feira"),
            new Cor("Preto", "19:00 - 20:40", "Quinta-feira"),
            new Cor("Rosa", "20:50 - 22:30", "Quinta-feira"),
            new Cor("Verde", "19:00 - 20:40", "Sexta-feira"),
            new Cor("Vermelho", "20:50 - 22:30", "Sexta-feira"),
        };
        public string Nome { get; set; }
        public string Horario { get; set; }
        public string Dia { get; set; }

        // -> Contrutor, constroi uma classe
        public Cor(string nome, string horario, string dia)
        {
            this.Nome = nome;
            this.Horario = horario;
            this.Dia = dia;
        }

        public override string ToString()
        {
            return this.Nome + " - " + this.Dia + ": " + this.Horario;
        }
    }
}
