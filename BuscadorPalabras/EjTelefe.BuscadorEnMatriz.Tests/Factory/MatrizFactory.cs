using EjTelefe.BuscadorEnMatriz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Tests
{
    public class MatrizFactory
    {
        public static Matriz<string> MatrizString4x4()
        {
            List<List<string>> contenido = new List<List<string>>() { new List<string>() { "1", "1", "1", "1" }, new List<string>() { "2", "2", "2", "2" }, new List<string>() { "3", "3", "3", "3" }, new List<string>() { "4", "4", "4", "4" } };

            return new Matriz<string>(contenido);
        }

        public static Matriz<ObjetoPrueba> MatrizObjeto2x2()
        {
            return new Matriz<ObjetoPrueba>(ListaObjeto2x2());
        }

        public static Matriz<ObjetoPrueba> MatrizObjeto1x2()
        {
            List<List<ObjetoPrueba>> contenido = new List<List<ObjetoPrueba>>() { new List<ObjetoPrueba>() { new ObjetoPrueba(1, 1) }, new List<ObjetoPrueba>() { new ObjetoPrueba(2, 1) } };

            return new Matriz<ObjetoPrueba>(contenido);
        }

        public static List<List<ObjetoPrueba>> ListaObjeto2x2()
        {
            return new List<List<ObjetoPrueba>>() { new List<ObjetoPrueba>() { new ObjetoPrueba(1, 1), new ObjetoPrueba(1, 2) }, new List<ObjetoPrueba>() { new ObjetoPrueba(2, 1), new ObjetoPrueba(2, 2) } };
        }

        public static Matriz<string> MatrizString()
        {
            string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };
            var contenidoMatriz = secuencias.Select(x => x.ToCharArray().Select(y => y.ToString()));
            return new Matriz<string>(contenidoMatriz);


        }

    }

}
