using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPermutaciones
{
    public static class Permutador
    {
        public static IEnumerable<string> Permutar(string palabra)
        {
            if (palabra == null)
                throw new ArgumentNullException("Palabra no puede ser null!");

            var permutaciones = new List<string>();
            
            if(palabra.Length == 0)
            {
                return permutaciones;
            }
            
            for (int i = 0; i < palabra.Length; i++)
            {
                var letra = palabra[i].ToString();
                var palabraRestante = palabra.Substring(0, i) + palabra.Substring(i + 1, palabra.Length - (i + 1));
                var permutacionesRestantes = Permutar(palabraRestante);

                if (permutacionesRestantes.Count() > 0)
                {
                    foreach (var permutacion in permutacionesRestantes)
                        permutaciones.Add(letra + permutacion);
                }
                else
                    permutaciones.Add(letra);
            }

            return permutaciones;
        }
    }
}
