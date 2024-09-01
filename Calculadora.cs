using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P2_Calculadora_MSDLTS
{
    //Clase que realiza las operaciones aritméticas.
    internal class Calculadora
    {
        //Método que suma los dos números proporcionados y devuelve el resultado.
        public float Sumar(Numero numeros)
        {
            return numeros.num1 + numeros.num2;
        }

        //Método que resta los dos números proporcionados y devuelve el resultado.
        public float Restar(Numero numeros)
        {
            return numeros.num1 - numeros.num2;
        }

        //Método que multiplica los dos números proporcionados y devuelve el resultado.
        public float Multiplicar(Numero numeros)
        {
            return numeros.num1 * numeros.num2;
        }

        //Método que divide el primer número por el segundo y devuelve el resultado.
        public float Dividir(Numero numeros)
        {
            if (numeros.num2 == 0)
            {
                //Lanzar una excepción si se intenta dividir por cero.
                throw new DivideByZeroException("No se puede dividir entre cero");
            }
            else
            {
                return numeros.num1 / numeros.num2;
            }
        }
    }
}
