using EjTelefe.BuscadorEnMatriz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz
{
    public class BuscadorDeObjetos<T> where T: class
    {
        public BuscadorDeObjetos(Matriz<T> matriz)
        {
            this.matriz = matriz;
        }

        private Matriz<T> matriz { get; set; }

        private static List<SentidoBusqueda> sentidosDeBusqueda = new List<SentidoBusqueda>()
        {
            SentidoBusqueda.Norte(), SentidoBusqueda.NorEste(), SentidoBusqueda.Este(), SentidoBusqueda.SurEste(), SentidoBusqueda.Sur(), SentidoBusqueda.SurOeste(), SentidoBusqueda.Oeste(), SentidoBusqueda.NorOeste()
        };

        public CoordenadasObjetoBuscado Buscar(T[] objetoABuscar)
        {
            List<Posicion> posicionesPrimerLetra = matriz.GetPosicionesAsList().Where(x => x.elem.Equals(objetoABuscar[0])).ToList();
            CoordenadasObjetoBuscado res = null;
            var encontrados = false;
            foreach (var posInicial in posicionesPrimerLetra)
            {
                res = BuscarTodoAlRededor(posInicial, objetoABuscar);
                if (res.encontrados)
                {
                    encontrados = true;
                    break;
                }
            }
            if (!encontrados)
                res = null;
            return res;
        }

        private CoordenadasObjetoBuscado BuscarTodoAlRededor(Posicion actual, T[] loQueBusco)
        {
            CoordenadasObjetoBuscado coordBuscadas = null;
            foreach (var sentido in sentidosDeBusqueda)
            {
                coordBuscadas = BuscarTodoEnElSentido(actual, loQueBusco, sentido);

                if (coordBuscadas.encontrados)
                    break;
            }
            return coordBuscadas;
        }

        private CoordenadasObjetoBuscado BuscarTodoEnElSentido(Posicion posicionInicial, T[] loQueBusco, SentidoBusqueda sentido)
        {
            CoordenadasObjetoBuscado res = new CoordenadasObjetoBuscado(loQueBusco);

            Posicion posActual = posicionInicial;

            for (int i = 0; i < loQueBusco.Length; i++)
            {
                if (posActual.elem != null && posActual.elem.Equals(loQueBusco[i]))
                    res.posiciones[i] = posActual;
                else
                {
                    res.encontrados = false;
                    break;
                }
                posActual = Siguiente(posActual, sentido);
            }

            return res;
        }

        private Posicion BuscarSiguiente(Posicion actual, SentidoBusqueda sentido, T loQueBusco)
        {
            var sgte = Siguiente(actual, sentido);

            if (sgte.elem != null && sgte.elem.Equals(loQueBusco))
                return sgte;
            else
                return null;
        }

        private Posicion Siguiente(Posicion actual, SentidoBusqueda sentido)
        {
            var next = matriz.GetPosicion(actual.X + sentido.X, actual.Y + sentido.Y);
            return next;
        }

    }
}
