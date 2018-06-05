using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Model
{
    public class Posicion 
    {
        public object elem { get; set; }
       
        public int X { get; set; }
        public int Y { get; set; }

        public Posicion(int X, int Y, object elem)
        {
            this.X = X;
            this.Y = Y;
            this.elem = elem;
        }

        public static Posicion PosicionInvalida(int X, int Y)
        {
            return new Posicion(X, Y, null);

        }

        public override bool Equals(object other)
        {
            if (other.GetType() == this.GetType())
                return this.X == (other as Posicion).X && this.Y == (other as Posicion).Y && this.elem.Equals((other as Posicion).elem);
            return false;
        }

    }
}
