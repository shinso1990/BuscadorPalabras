using EjTelefe.BuscadorEnMatriz.Model;
using EjTelefe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EjTelefe.WebApi.Controllers
{
    public class BuscadorDePalabrasController : ApiController
    {
        // GET: api/BuscadorDePalabras
        public List<PalabrasBuscadas> Get()
        {
            return ComunicadorPalabrasBuscadas.GetAll();
        }


        // GET: api/BuscadorDePalabras/5
        public List<int[]> GetWord(string word)
        {
            new Task(() => ComunicadorPalabrasBuscadas.SaveWord(word)).Start();
            var letters = word.ToCharArray().Select(x => x.ToString()).ToArray();
            return BuscarEnSecuenciaFija(letters);
        }
        



        string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };

        private List<int[]> BuscarEnSecuenciaFija(string[] letters)
        {
            var contenidoMatriz = secuencias.Select(x => x.ToCharArray().Select(y => y.ToString()));

            var MatrizDeBusqueda = new Matriz<string>(contenidoMatriz);
            var Buscador = new BuscadorEnMatriz.BuscadorDeObjetos<string>(MatrizDeBusqueda);

            var res = Buscador.Buscar(letters);
            if (res.encontrados)
                return res.posiciones.Select(x => new int[2] { x.Y, x.X }).ToList();
            else
                return new List<int[]>();
            
        }
        


    }
}
