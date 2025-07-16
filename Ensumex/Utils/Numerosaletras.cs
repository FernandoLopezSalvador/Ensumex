using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Utils
{
    internal class Numerosaletras
    {
        private static readonly string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        private static readonly string[] decenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static readonly string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public static string Convertir(decimal numero)
        {
            long parteEntera = (long)Math.Floor(numero);
            int centavos = (int)((numero - parteEntera) * 100);

            string textoEntero = ConvertirNumero(parteEntera);
            string textoCentavos = centavos.ToString("00") + "/100 M.N.";

            // Convierte la primera letra a mayúscula
            string resultado = $"({textoEntero} pesos {textoCentavos})";
            resultado = char.ToUpper(resultado[1]) + resultado.Substring(2); 

            return resultado;
        }
        private static string ConvertirNumero(long numero)
        {
            if (numero == 0) return "cero";
            if (numero == 100) return "cien";
            if (numero < 10) return unidades[numero];
            if (numero < 100)
            {
                int unidad = (int)(numero % 10);
                int decena = (int)(numero / 10);

                if (unidad == 0)
                    return decenas[decena];
                else if (decena == 1)
                {
                    if (unidad == 1) return "once";
                    if (unidad == 2) return "doce";
                    if (unidad == 3) return "trece";
                    if (unidad == 4) return "catorce";
                    if (unidad == 5) return "quince";
                    return "dieci" + unidades[unidad];
                }
                else if (decena == 2)
                {
                    return "veinti" + unidades[unidad];
                }
                else
                {
                    return decenas[decena] + " y " + unidades[unidad];
                }
            }
            if (numero < 1000)
            {
                long resto = numero % 100;
                long centena = numero / 100;
                return centenas[centena] + ((resto > 0) ? " " + ConvertirNumero(resto) : "");
            }
            if (numero < 1000000)
            {
                long miles = numero / 1000;
                long resto = numero % 1000;
                string milesTexto = (miles == 1) ? "mil" : ConvertirNumero(miles) + " mil";
                return milesTexto + ((resto > 0) ? " " + ConvertirNumero(resto) : "");
            }
            if (numero < 1000000000000)
            {
                long millones = numero / 1000000;
                long resto = numero % 1000000;
                string millonesTexto = (millones == 1) ? "un millón" : ConvertirNumero(millones) + " millones";
                return millonesTexto + ((resto > 0) ? " " + ConvertirNumero(resto) : "");
            }
            return numero.ToString();
        }
    }
}