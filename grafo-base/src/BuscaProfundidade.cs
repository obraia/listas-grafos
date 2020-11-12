using System;
using System.Collections.Generic;

namespace grafo {

    class BuscaProfundidade {
      
         public int Buscar(Grafo grafo) {

            int componentes = 0;
            
            // -> Percorrer todos os vértoces do grafo
            grafo.Vertices.ForEach(v => {
                if(v.Cor == "Branco") {
                    Visitar(v);
                    componentes++;
                }
            });

            return componentes;
        }

        public void Visitar(Vertice v) {
            v.Cor = "Cinza";

            v.ListaAdjacencia.ForEach(a => {
                if(a.Vertice.Cor == "Branco") Visitar(a.Vertice);
                a.Vertice.Cor = "Preto";
            });
        }
    }
}
