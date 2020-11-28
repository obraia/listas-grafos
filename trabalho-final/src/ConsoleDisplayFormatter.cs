using System;
using System.Linq;

namespace grafo
{
    public class ConsoleDisplayFormatter
    {
        public static int TableWidth = 160;

        // -> Método para criar separadores na tabela
        public static void PrintSeperatorLine()
        {
            Console.WriteLine(new string('-', TableWidth + 1));
        }

        // -> Método para escrever cada linha da tabela
        public static void PrintRow(params string[] columns)
        {
            int columnWidth = (TableWidth - columns.Length) / columns.Length;
            const string columnSeperator = "|";

            string row = columns.Aggregate(columnSeperator, (seperator, columnText) => seperator + GetCenterAlignedText(columnText, columnWidth) + columnSeperator);

            Console.WriteLine(row);
        }

        // -> Método para centralizar texto a ser exibido na tabela
        private static string GetCenterAlignedText(string text, int columnWidth)
        {
            text = text.Length > columnWidth ? text.Substring(0, columnWidth - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', columnWidth)
                : text.PadRight(columnWidth - ((columnWidth - text.Length) / 2)).PadLeft(columnWidth);
        }
    }
}
