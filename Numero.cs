using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Calculadora_MSDLTS
{
    //Clase que representa los números involucrados en las operaciones.
    internal class Numero
    {
        //Primer número.
        public float num1 {  get; set; }
        //Segundo número.
        public float num2 { get; set; }

        //Constructor que inicializa los números.
        public Numero(float num1, float num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }
    }
}
