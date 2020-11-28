using System.Collections.Generic;

namespace grafo
{
    // -> Interface para definir estrutura da tabela
    public interface IPrintTabularData<Professor>
    {
        void PrintTable(IEnumerable<Professor> data);
    }
}
