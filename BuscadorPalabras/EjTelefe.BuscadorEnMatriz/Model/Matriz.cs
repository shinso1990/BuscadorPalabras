using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Model
{
    public class Matriz<T> where T: class
    {
        public int alto { get; set; }
        public int ancho { get; set; }
        private Posicion[][] matriz { get; set; }

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

        public Posicion GetPosicion( int x , int y)
        {
            if (x > ancho  || y > alto || x == 0 || y == 0)
                return Posicion.PosicionInvalida(x,y);
            return matriz[y-1][x-1];
        }

        public List<Posicion> GetPosicionesAsList()
        {
            List<Posicion> res = new List<Posicion>();
            matriz.ToList().ForEach(x => x.ToList().ForEach(y => res.Add(y)));

            return res;
        }

    }
}
