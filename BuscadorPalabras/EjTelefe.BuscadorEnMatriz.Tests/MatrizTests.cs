using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EjTelefe.BuscadorEnMatriz.Model;
using System.Collections.Generic;

namespace EjTelefe.BuscadorEnMatriz.Tests
{
    [TestClass]
    public class MatrizTests
    {
        [TestMethod]
        public void TamanioMatrizCorrecto()
        {
            var mat =MatrizFactory.MatrizObjeto1x2();
            Assert.AreEqual(2, mat.alto);
            Assert.AreEqual(1, mat.ancho);
        }

        [TestMethod]
        public void SiPosicionInvalidaElementoNulo()
        {
            var mat = MatrizFactory.MatrizObjeto2x2();
            Assert.IsNull(mat.GetPosicion(3, 1).elem);

        }

        [TestMethod]
        public void PosicionMatriz()
        {
            var mat = MatrizFactory.MatrizString4x4();
            Assert.IsNotNull(mat.GetPosicion(1, 1));
            Assert.IsNotNull(mat.GetPosicion(1, 1).elem);
        }

        [TestMethod]
        public void ContenidoCorrectoEnMatriz()
        {
            var listado = MatrizFactory.ListaObjeto2x2();
            var mat = new Matriz<ObjetoPrueba>(listado);

            Assert.AreEqual(mat.GetPosicion(1, 1).elem, listado[0][0]);
            Assert.AreEqual(mat.GetPosicion(1, 2).elem, listado[1][0]);
            Assert.AreEqual(mat.GetPosicion(2, 1).elem, listado[0][1]);
            Assert.AreEqual(mat.GetPosicion(2, 2).elem, listado[1][1]);
        }

        


    }

    
    
}
