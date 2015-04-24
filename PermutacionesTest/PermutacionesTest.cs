using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EjercicioPermutaciones
{
    public class PermutacionesTest
    {
        private string Letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

        [Fact]
        public void PermutacionesVacioTest()
        {
            string vacio = "";
            var result = Permutador.Permutar(vacio);

            Assert.Equal(new List<string>(), result);
        }

        [Fact]
        public void PermutacionesUnaLetraTest()
        {
            Random r = new Random((int)DateTime.Now.Ticks);

            string letra = Letras[r.Next(Letras.Length)].ToString();
            
            var result = Permutador.Permutar(letra);
            var expected = new List<string>() { letra };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void PermutacionesDosLetrasTest()
        {

            var letra1 = GetLetra();
            var letra2 = GetLetra();
            string palabra =  letra1 + letra2;

            var result = Permutador.Permutar(palabra);
            var expected = new List<string>() { letra1 + letra2 , letra2 + letra1};
            Console.WriteLine(result.ToString());

            Assert.Equal(expected, result);
        }

        [Fact]
        public void PermutacionesTresLetrasTest()
        {

            var letra1 = GetLetra();
            var letra2 = GetLetra();
            var letra3 = GetLetra();
            string palabra = letra1 + letra2 + letra3;

            var result = Permutador.Permutar(palabra);
            var expected = new List<string>() 
            { 
                letra1 + letra2 + letra3, 
                letra1 + letra3 + letra2, 
                letra2 + letra3 + letra1, 
                letra2 + letra1 + letra3, 
                letra3 + letra1 + letra2, 
                letra3 + letra2 + letra1, 
            };

            
            expected.Sort();
            var resultList = result.ToList();
            resultList.Sort();
            Assert.Equal(expected, resultList);
        }

        [Fact]
        public void PermutacionesNLetrasTest()
        {
            var palabra = "";

            Random r = new Random((int)DateTime.Now.Ticks);

            int largoPalabra = r.Next(4, 10);

            for (int i = 0; i < largoPalabra; i++)
                palabra += GetLetra();
            
            var result = Permutador.Permutar(palabra);
            
            var cantPalabrasEsperadas = 1;
            for(int i = largoPalabra; i > 1; i--)
                cantPalabrasEsperadas *= i;

            Assert.Equal(cantPalabrasEsperadas, result.Count());
        }
        private string GetLetra()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            
            return Letras[r.Next(Letras.Length)].ToString();
        }
    }
}
