using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Model
{
    public class CoordenadasObjetoBuscado
    {
        public CoordenadasObjetoBuscado(object[] objetosBuscados)
        {
            this.objetosBuscados = objetosBuscados;
            this.encontrados = true;
            this.posiciones = new Posicion[objetosBuscados.Length];
        }

        public bool encontrados { get; set; }
        public object[] objetosBuscados { get; set; }
        public Posicion[] posiciones { get; set; }
        
    }
}
