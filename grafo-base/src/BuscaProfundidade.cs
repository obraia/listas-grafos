using System;
using System.Collections.Generic;

namespace grafo
{

    class BuscaProfundidade
    {
        public static int TempoDescoberta = 0;

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

        public void Visitar(Vertice v)
        {
            v.TempoEntrada = TempoDescoberta++;
            v.SetCorCinza();

            v.ListaAdjacencia.ForEach(a =>
            {
                if(v.Cor == "Cinza" && a.Vertice.Cor == "Branco") {
                    a.TipoAresta = "Árvore";
                }
                else if((v.Cor == "Cinza" || v.Cor == "Preto") && a.Vertice.Cor == "Cinza")
                {
                    a.TipoAresta = "Retorno";
                }
                else if (v.Cor == "Cinza" && a.Vertice.Cor == "Preto")
                {
                    if(v.TempoEntrada > a.Vertice.TempoEntrada) a.TipoAresta = "Cruzamento";
                    else a.TipoAresta = "Avanço";
                }

                if (a.Vertice.Cor == "Branco") Visitar(a.Vertice);
                a.Vertice.SetCorPreto();
                v.TempoSaida = TempoDescoberta++;
            });
        }
    }
}
