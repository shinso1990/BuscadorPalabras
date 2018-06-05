using EjTelefe.BuscadorEnMatriz.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Tests
{
    [TestClass]
    public class BuscadorTests
    {
        [TestMethod]
        public void PalabraEncontrada()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "J", "A", "V", "A" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 4);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(2, 2, "J")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(3, 3, "A")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(4, 4, "V")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(5, 5, "A")));

        }

        [TestMethod]
        public void PalabraNoEncontrada()
        {
            var mat = MatrizFactory.MatrizString();

            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "Z", "Z", "Z" });

            Assert.IsNull(res);
        }

        [TestMethod]
        public void PrimerAparicionPalabra()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "H"});

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 1);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(2, 3, "H")));

        }

        [TestMethod]
        public void BuscarPalabraSentidoEste()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "T", "E", "L", "E","F","E" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 6);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(1, 7, "T")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(2, 7, "E")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(3, 7, "L")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(4, 7, "E")));
            Assert.IsTrue(res.posiciones[4].Equals(new Posicion(5, 7, "F")));
            Assert.IsTrue(res.posiciones[5].Equals(new Posicion(6, 7, "E")));
        }

        [TestMethod]
        public void BuscarPalabraSentidoOeste()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "E", "F", "E", "L", "E", "T" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 6);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(6, 7, "E")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(5, 7, "F")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(4, 7, "E")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(3, 7, "L")));
            Assert.IsTrue(res.posiciones[4].Equals(new Posicion(2, 7, "E")));
            Assert.IsTrue(res.posiciones[5].Equals(new Posicion(1, 7, "T")));
        }


        [TestMethod]
        public void BuscarPalabraSentidoSurEste()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "I", "O", "T" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 3);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(3, 2, "I")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(4, 3, "O")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(5, 4, "T")));
        }

        [TestMethod]
        public void BuscarPalabraSentidoNorOeste()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "T","O", "I" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 3);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(5, 4, "T")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(4, 3, "O")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(3, 2, "I")));
            
        }

        [TestMethod]
        public void BuscarPalabraSentidoNorEste()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "R", "A", "L", "F" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 4);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(2, 4, "R")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(3, 3, "A")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(4, 2, "L")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(5, 1, "F")));
        }

        [TestMethod]
        public void BuscarPalabraSentidoSurOeste()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "F", "L", "A", "R" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 4);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(5, 1, "F")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(4, 2, "L")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(3, 3, "A")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(2, 4, "R")));
        }

        [TestMethod]
        public void BuscarPalabraSentidoSur()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "V", "I", "A", "C", "O","M" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 6);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(3, 1, "V")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(3, 2, "I")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(3, 3, "A")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(3, 4, "C")));
            Assert.IsTrue(res.posiciones[4].Equals(new Posicion(3, 5, "O")));
            Assert.IsTrue(res.posiciones[5].Equals(new Posicion(3, 6, "M")));
        }


        [TestMethod]
        public void BuscarPalabraSentidoNorte()
        {
            var mat = MatrizFactory.MatrizString();
            var buscador = new BuscadorDeObjetos<string>(mat);
            var res = buscador.Buscar(new string[] { "M", "O", "C", "A", "I", "V" });

            Assert.IsTrue(res.encontrados);
            Assert.IsTrue(res.posiciones.Length == 6);
            Assert.IsTrue(res.posiciones[0].Equals(new Posicion(3, 6, "M")));
            Assert.IsTrue(res.posiciones[1].Equals(new Posicion(3, 5, "O")));
            Assert.IsTrue(res.posiciones[2].Equals(new Posicion(3, 4, "C")));
            Assert.IsTrue(res.posiciones[3].Equals(new Posicion(3, 3, "A")));
            Assert.IsTrue(res.posiciones[4].Equals(new Posicion(3, 2, "I")));
            Assert.IsTrue(res.posiciones[5].Equals(new Posicion(3, 1, "V")));
        }


    }
}
