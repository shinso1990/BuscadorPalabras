using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorPalabras.Model
{
    public class Matriz<T> where T: class
    {
        public int alto { get; set; }
        public int ancho { get; set; }
        public Posicion[][] matriz { get; set; }

        public Matriz(IEnumerable<IEnumerable<T>> lobj)
        {
            matriz = new Posicion[lobj.Count()][]; 

            for (int y = 0; y < lobj.Count(); y++ )
            {
                matriz[y] = new Posicion[lobj.ElementAt(y).Count()];

                for(int x = 0; x < lobj.ElementAt(y).Count(); x++)
                    matriz[y][x] = new Posicion(x + 1, y + 1, lobj.ElementAt(y).ElementAt(x));
            }

            alto = matriz.Length;
            ancho = matriz[0].Length;
        }

        private static List<SentidoBusqueda> sentidosDeBusqueda = new List<SentidoBusqueda>()
        {
            SentidoBusqueda.Norte(), SentidoBusqueda.NorEste(), SentidoBusqueda.Este(), SentidoBusqueda.SurEste(), SentidoBusqueda.Sur(), SentidoBusqueda.SurOeste(), SentidoBusqueda.Oeste(), SentidoBusqueda.NorOeste()
        };

        public CoordenadasObjetoBuscado Buscar(T[] objetoABuscar) 
        {

            List<Posicion> posicionesPrimerLetra = new List<Posicion>();

            matriz.ToList().ForEach(x => x.ToList().ForEach(y => {
                if (y.elem.Equals( objetoABuscar[0]))
                    posicionesPrimerLetra.Add(y);
                }
            ));

            CoordenadasObjetoBuscado res= null;
            foreach ( var posInicial in posicionesPrimerLetra)
            {
                res = BuscarTodoAlRededor(posInicial, objetoABuscar);
                if (res.encontrados)
                    break;
            }
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

        private Posicion Siguiente( Posicion actual, SentidoBusqueda sentido)
        {
            var next = GetPosicion(actual.X + sentido.X, actual.Y + sentido.Y);
            return next;
        }

        public Posicion GetPosicion( int x , int y)
        {
            if (x > ancho  || y > alto || x == 0 || y == 0)
                return Posicion.PosicionInvalida(x,y);
            return matriz[y-1][x-1];
        }

    }
}
