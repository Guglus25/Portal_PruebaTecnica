using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_PruebaTecnica.Models
{
    public class clsCadena
    {
        public string strIteracion { get; set; }
        public clsCadena()
        {
            strIteracion = String.Empty;
        }

        public string Prueba_Tecnica(string strPrincipal, Int64 intTop)
        {
            Random inta = new Random();
            Random oRandom = new Random(inta.Next());
            char[] chArrayPrincipal = new char[26];
            char[,] chMatrizRandom = new char[50, 26];


            string strIteracion1 = "";

            string strABC = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char Letra;
            string strNueva = "";
            int intPunto = 0, intPosicion = 0, intMayor = 0;

            try
            {
                chArrayPrincipal = strPrincipal.ToCharArray(0, 26);


                for (int A = 0; A < chMatrizRandom.GetLength(0); A++)
                {
                    for (int i = 0; i < strPrincipal.Length; i++)
                    {
                        Letra = strPrincipal[oRandom.Next(0, strPrincipal.Length - 1)];
                        chMatrizRandom[A, i] = Letra;
                    }
                }



                for (int A = 0; A < chMatrizRandom.GetLength(0); A++)
                {
                    for (int i = 0; i < chArrayPrincipal.Length; i++)
                    {
                        if (chMatrizRandom[A, i] == chArrayPrincipal[i])
                        {
                            intPunto = intPunto + 1;
                        }
                    }

                    if (intMayor <= intPunto)
                    {
                        intMayor = intPunto;
                        intPosicion = A;

                    }
                    intPunto = 0;
                }


                for (int i = 0; i < chArrayPrincipal.Length; i++)
                {
                    strNueva += chMatrizRandom[intPosicion, i];
                }

                if (intMayor < 26)
                {
                    strIteracion1 = strIteracion1 + intTop + ". " + strNueva + " = " + intMayor + "<br> ";
                    intMayor = 0;
                    strIteracion1 = strIteracion1 + Prueba_Tecnica(strNueva, intTop + 1);
                }
                else
                {
                    strIteracion1 = strIteracion1 + intTop + ". " + strNueva + " = " + intMayor + "<br> ";
                }
                return strIteracion1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
