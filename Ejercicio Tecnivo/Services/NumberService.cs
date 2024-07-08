using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ejercicio_Tecnivo.Services
{
    public class NumberService
    {
        private static readonly string[] Units = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        private static readonly string[] Tens = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static readonly string[] Teens = { "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        private static readonly string[] Hundreds = { "", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public string GetPronunciation(long number)
        {
            if (number == 0) return "cero";

            return ConvertNumberToWords(number);
        }

        private string ConvertNumberToWords(long number)
        {
            if (number < 0)
                return "menos " + ConvertNumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000000) + " billón ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000) + " millón ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertNumberToWords(number / 1000) + " mil ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += Hundreds[number / 100] + " ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "y ";

                if (number < 10)
                    words += Units[number];
                else if (number < 20)
                    words += Teens[number - 10];
                else
                {
                    words += Tens[number / 10];
                    if ((number % 10) > 0)
                        words += " y " + Units[number % 10];
                }
            }

            return words.Trim();
        }
    }
}

