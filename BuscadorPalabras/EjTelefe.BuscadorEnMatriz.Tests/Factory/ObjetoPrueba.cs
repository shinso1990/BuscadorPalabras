using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.BuscadorEnMatriz.Tests
{
    public class ObjetoPrueba : IEqualityComparer<ObjetoPrueba>
    {

        public ObjetoPrueba(int algo1, int algo2)
        {
            this.algo2 = algo2;
            this.algo1 = algo1;
        }

        public int algo1 { get; set; }
        public int algo2 { get; set; }


        public bool Equals(ObjetoPrueba x, ObjetoPrueba y)
        {
            return x.algo1 == y.algo1 && x.algo2 == y.algo2;
        }

        public int GetHashCode(ObjetoPrueba obj)
        {
            throw new NotImplementedException();
        }
    }

}
