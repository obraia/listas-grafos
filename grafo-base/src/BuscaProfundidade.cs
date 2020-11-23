using System;
using System.Collections.Generic;
using System.Linq;

namespace grafo
{

    class BuscaProfundidade
    {
        public static int TempoDescoberta = 1;

        // -> Da inicio a busca em profundidade
        public int Buscar(Grafo grafo)
        {
            grafo.ResetCoresVertices();
            grafo.ResetTemposVertices();
            grafo.ResetTipoArestas();

            int componentes = 0;

            // -> Percorrer todos os vértoces do grafo
            grafo.Vertices.ForEach(v =>
            {
                if (v.Cor == "Branco")
                {
                    Visitar(v);
                    componentes++;
                }
            });

            return componentes;
        }

        // -> Método para realizar visitas aos vértices 
        public void Visitar(Vertice v)
        {
            v.TempoEntrada = TempoDescoberta;
            TempoDescoberta++;
            v.SetCorCinza();

            // Console.WriteLine(v.Id + " -> Entrada: " + v.TempoEntrada);

            v.ListaAdjacencia.ForEach(a =>
            {
                // -> Caso a aresta não tenha classificação, classificá-la
                if ((a.TipoAresta is null)) this.ClassificarAresta(v, a);
                if (a.Vertice.Cor == "Branco") Visitar(a.Vertice);

            });

            // -> Se Vertice v não tem adjacentes marcar tempo de saída
            v.TempoSaida = TempoDescoberta;
            TempoDescoberta++;
            v.SetCorPreto();

            // System.Console.WriteLine(v.Id + " -> Saída: " + v.TempoSaida);
        }

        // -> Método para classificar as arestas
        public void ClassificarAresta(Vertice v, Aresta a)
        {
            if (v.Cor == "Cinza" && a.Vertice.Cor == "Branco")
            {
                a.TipoAresta = "Árvore";
            }
            else if ((v.Cor == "Cinza" || v.Cor == "Preto") && a.Vertice.Cor == "Cinza")
            {
                a.TipoAresta = "Retorno";
            }
            else if ((v.Cor == "Cinza" || v.Cor == "Preto") && a.Vertice.Cor == "Preto")
            {
                if (v.TempoEntrada > a.Vertice.TempoEntrada) a.TipoAresta = "Cruzamento";
                else a.TipoAresta = "Avanço";
            }
        }
    }
}
