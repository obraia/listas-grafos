using System;

namespace grafo
{
    public class Cor
    {
        // -> 11 cores pré-definidas com seus respectivos horários 
        public static Cor[] Cores = {
            new Cor("Amarelo", "19:00 - 20:40", "Segunda-feira"),
            new Cor("Azul", "20:50 - 22:30", "Segunda-feira"),
            new Cor("Branco", "19:00 - 20:40", "Terça-feira"),
            new Cor("Cinza", "20:50 - 22:30", "Terça-feira"),
            new Cor("Magenta", "19:00 - 20:40", "Quarta-feira"),
            new Cor("Ciano", "20:50 - 22:30", "Quarta-feira"),
            new Cor("Verde-escuro", "19:00 - 20:40", "Quinta-feira"),
            new Cor("Vinho", "20:50 - 22:30", "Quinta-feira"),
            new Cor("Verde", "19:00 - 20:40", "Sexta-feira"),
            new Cor("Vermelho", "20:50 - 22:30", "Sexta-feira"),
            new Cor("Roxo", "08:50 - 10:30", "Sábado"),
        };
        public string Nome { get; set; }
        public string Horario { get; set; }
        public string Dia { get; set; }

        // -> Contrutor, que inicia nome, horário e dia
        public Cor(string nome, string horario, string dia)
        {
            this.Nome = nome;
            this.Horario = horario;
            this.Dia = dia;
        }

        // -> Retorna um valor para cmparar dias
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

        // -> Retorna um valor para cmparar horas
        public static int ValorHora(string hora)
        {
            return hora != "" ? int.Parse(hora.Substring(0, 2)) : -1;
        }

        // -> Retorna uma cor baseado em seu nome
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

        public override string ToString()
        {
            return this.Dia + ": " + this.Horario;
        }
    }
}
