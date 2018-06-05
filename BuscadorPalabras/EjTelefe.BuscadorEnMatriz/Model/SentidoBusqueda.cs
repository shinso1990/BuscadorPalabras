using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Model
{
    public class SentidoBusqueda 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SentidoBusqueda(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static SentidoBusqueda Norte()
        {
            return new SentidoBusqueda(0,1);
        }
        public static SentidoBusqueda NorEste()
        {
            return new SentidoBusqueda(1, 1);
        }
        public static SentidoBusqueda Este()
        {
            return new SentidoBusqueda(1, 0);
        }
        public static SentidoBusqueda SurEste()
        {
            return new SentidoBusqueda(1, -1);
        }
        public static SentidoBusqueda Sur()
        {
            return new SentidoBusqueda(0, -1);
        }
        public static SentidoBusqueda SurOeste()
        {
            return new SentidoBusqueda(-1, -1);
        }
        public static SentidoBusqueda Oeste()
        {
            return new SentidoBusqueda(-1, 0);
        }
        public static SentidoBusqueda NorOeste()
        {
            return new SentidoBusqueda(-1, 1);
        }

    }
}
