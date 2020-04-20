using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_laboratorio_2
{
    class Calculadora
    {

        /// <summary>
        /// Valida que el operador seleccionado este entre las opciones, sino devuelve "+".
        /// </summary>
        /// <param name="operador">El operador seleccionado por comboBox</param>
        /// <returns>Retorna el operador validado</returns>
        private static string ValidarOperador(string operador)
        {
         
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
            
                operador = "+";
            
            }
            
            return operador;
        }

        /// <summary>
        /// Realiza la operación con los parametros recibidos.
        /// </summary>
        /// <param name="num1">Primer numero a operar</param>
        /// <param name="num2">Segundo numero a operar</param>
        /// <param name="oper">Operador indicado para la operacion</param>
        /// <returns>El resultado de la operacion como string</returns>
        public static string Operar(Numero num1, Numero num2, string oper)
        {
            
            string rta = "";
            
            Numero aux = new Numero(0);

            switch (oper = ValidarOperador(oper))
            {

                case "+":

                    rta = (num1 + num2) + "";

                    break;

                case "-":

                    rta = (num1 - num2) + "";

                    break;

                case "*":

                    rta = (num1 * num2) + "";

                    break;

                case "/":

                    if ((num2 - aux) == 0)
                    {

                        rta = "Error";

                    }

                    else
                    {

                        rta = (num1 / num2) + "";

                    }

                    break;

            }

            return rta;

        }
    }
}
