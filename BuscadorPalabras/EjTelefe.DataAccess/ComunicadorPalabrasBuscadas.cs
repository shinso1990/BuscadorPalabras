using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTelefe.DataAccess
{
    public class ComunicadorPalabrasBuscadas
    {

        public static List<PalabrasBuscadas> GetAll()
        {
            using (var r = new DBEntities())
            {
                return r.PalabrasBuscadas.OrderByDescending(x => x.FechaBusqueda).ToList();
            }
        }

        public static void Save(PalabrasBuscadas pb)
        {
            using (var r = new DBEntities())
            {
                r.PalabrasBuscadas.Add(pb);
                r.SaveChanges();
            }
        }

        public static void SaveWord(string word)
        {
            Save(new PalabrasBuscadas() { PalabraBuscada = word, FechaBusqueda= DateTime.Now });
        }

    }
}
