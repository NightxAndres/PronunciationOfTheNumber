namespace PronunciationOfTheNumber.Services
{
    public class NumberPronunciationService
    {
        private string[] units = { "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        private string[] particular = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        private string[] dozens = { "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private string[] hundreds = { "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
        private bool un = false;
        private bool uno = false;
        private bool finishhOne = false;
        private string numberToString = "";


        public string Transform(long number)
        {
            string words = "";
            string numberToString = number.ToString();

            if (numberToString.EndsWith("21"))
            {
                finishhOne = true;
            }

            if (number >= 0 && number <= 999999999999)
            {
                if (number == 0)
                {
                    return "cero";
                }

                if ((number / 1000000000) > 0)
                {
                    if (number / 1000000000 == 1)
                    {
                        words += "un billón ";
                    }
                    else
                    {
                        un = true;
                        words += Transform(number / 1000000000) + " billones "; /*Recursividad*/
                    }
                    number %= 1000000000;
                    uno = true;

                }

                if ((number / 1000000) > 0)
                {
                    if (number >= 1000000 && number <= 1999999)
                    {
                        words += Transform(number / 1000000) + " millón "; /*Recursividad*/
                    }
                    else
                    {
                        un = true;

                        words += Transform(number / 1000000) + " millones "; /*Recursividad*/

                    }
                    number %= 1000000;
                    uno = true;
                }

                if ((number / 1000) > 0)
                {
                    if (number / 1000 == 1)
                    {
                        words += "mil ";

                    }
                    else
                    {
                        un = true;
                        words += Transform(number / 1000) + " mil "; /*Recursividad*/
                    }
                    number %= 1000;
                    //
                    uno = true;
                }

                if ((number / 100) > 0)
                {
                    if (number / 100 == 1 && number % 100 == 0)
                    {
                        words += "cien ";
                    }
                    else
                    {
                        words += hundreds[(number / 100) - 1] + " ";
                    }
                    number %= 100;

                }

                if (number > 0)
                {
                    if (number < 20)
                    {
                        if (number == 1)
                        {
                            if (uno)
                            {
                                words += "uno";
                            }
                            else
                            {
                                words += "un";
                            }
                        }
                        else
                        {
                            words += (number < 10) ? units[number - 1] : particular[number - 10];
                        }

                    }
                    else
                    {
                        if (number >= 21 && number <= 29)
                        {
                            words += "veinti";
                        }
                        else
                        {
                            words += dozens[(number / 10) - 1];
                        }
                        if ((number % 10) > 0)

                            if (number == 21)
                            {
                                if (words.Contains("mil") && finishhOne)
                                {
                                    words += "uno";

                                }
                                else if (un)
                                {
                                    words += "ún";
                                }
                                else
                                {
                                    words += units[(number % 10) - 1];
                                }
                            }
                            else
                            {
                                if (number >= 22 && number <= 29)
                                {
                                    words += units[(number % 10) - 1];
                                }
                                else if (un && (number == 31 || number == 41 || number == 51 || number == 61 || number == 71 || number == 81 || number == 91))
                                {
                                    words += " y un";
                                }
                                else
                                {
                                    words += " y " + units[(number % 10) - 1];

                                }
                            }

                    }
                }

                return words;

            }
            else
            {
                return "El número que ingresaste esta fuera del rango [0 - 999.999.999.999]";
            }

            // Este bloque de codigo sirve si se quiere aunmentar el rango de los numeros al plano de los reales
            //if (numero < 0)
            //    return "menos " + Convertir(Math.Abs(numero));
        }
    }
}
