using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace grafo
{
    public sealed class TablePrinter<TData> : IPrintTabularData<Professor>
    {
        // -> Método para exibir a tabela em tela
        public void PrintTable(IEnumerable<Professor> data)
        {
            PropertyInfo[] propertyInfos = typeof(TData).GetProperties();

            // -> Define o cabeçalho da nossa tabela
            var propertyNames = propertyInfos
            .Where(propertyInfos => propertyInfos.Name != "Id")
            .Select(propInfo => propInfo.Name).ToArray();

            propertyNames[1] = "Professor";
            propertyNames[3] = "Dias da semana";

            ConsoleDisplayFormatter.PrintSeperatorLine();
            ConsoleDisplayFormatter.PrintRow(propertyNames);
            ConsoleDisplayFormatter.PrintSeperatorLine();

            // -> Lista todo o corpo da nossa tabela
            foreach (var datum in data)
            {
                var values = propertyInfos
                .Where(propInfo => propInfo.Name != "Id")
                .Select(propInfo => propInfo.GetValue(datum, null).ToString()).ToArray();

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = Cor.ValorCor(datum.Cor.Nome);

                ConsoleDisplayFormatter.PrintRow(values);
            }

            ConsoleDisplayFormatter.PrintSeperatorLine();
            Console.ResetColor();
        }
    }
}
