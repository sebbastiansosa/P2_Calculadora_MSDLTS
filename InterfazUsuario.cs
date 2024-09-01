using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Calculadora_MSDLTS
{
    //Clase que maneja la interacción con el usuario y el menú de operaciones.
    internal class InterfazUsuario
    {
        //Instancia de la clase Calculadora para realizar las operaciones.
        private Calculadora calculadora;
        //Lista de opciones del menú
        private List<Opcion> opciones;
        //Instancia de la clase Numero para almacenar los números ingresados.
        private Numero numeros;

        //Constructor que inicializa la calculadora y las opciones del menú.
        public InterfazUsuario()
        {
            calculadora = new Calculadora();
            opciones = new List<Opcion>
            {
                //Opción para sumar números.
                new Opcion("Sumar", Sumar),
                //Opción para restar números.
                new Opcion("Restar", Restar),
                //Opción para multiplicar números.
                new Opcion("Multiplicar", Multiplicar),
                //Opción para dividir números.
                new Opcion("Dividir", Dividir),
                //Opcion para salir del programa.
                new Opcion("Salir del programa", () => Environment.Exit(0))
            };
        }

        //Método principal que inicia la interacción con el usuario.
        public void Iniciar()
        {
            while (true)
            {
                //Solicitar números al usuario.
                PedirNumeros();
                while (true)
                {
                    //Mostrar el menú de opciones.
                    MostarMenu();
                    //Ejecutar la opción seleccionada por el usuario.
                    SeleccionarOpcion();
                    //Mostrar un nuevo menú de opciones despúes de mostrar el resultado.
                    MenuPostResultado();
                }
            }
        }

        //Método que muestra las opciones del menú en la consola.
        private void MostarMenu()
        {
            Console.WriteLine("Menú de Calculadora:");
            for (int i = 0; i < opciones.Count; i++)
            {
                //Mostrar cada opción con su número correspondiente.
                Console.WriteLine($"{i+1}. {opciones[i].Message}");
            }
        }

        //Método que solicita al usuario seleccionar una opción del menú y ejecuta la acción correspondiente.
        private void SeleccionarOpcion()
        {
            Console.Write("\nSelecciona una opción: ");
            try
            {
                //Leer y ajustar la opción seleccionada.
                int numOpcion = Convert.ToInt32(Console.ReadLine()) - 1;

                if (numOpcion >= 0 && numOpcion < opciones.Count)
                {
                    //Ejecutar la acción de la opción seleccionada.
                    Console.Clear();
                    opciones[numOpcion].Action.Invoke();
                }
                else
                {
                    //Vuelve a solicitar la selección de opción si la opción no es válida.
                    Console.WriteLine("Opción no válida. Inténtalo nuevamente.\n");
                    MostarMenu();
                    SeleccionarOpcion();
                }
            }
            catch (Exception e)
            {
                //Volver a mostrar el menú y la solicitud de selección de opción en caso de error.
                Console.WriteLine("No has introducido un valor numérico válido.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
                MostarMenu();
                SeleccionarOpcion();
            }
        }

        //Solicita al usuario que ingrese dos números y los almacena en una instancia de Numero.
        private void PedirNumeros()
        {
            try
            {
                //Leer y convertir el primer número.
                Console.Write("Ingresa el primer número: ");
                float num1 = float.Parse(Console.ReadLine());

                //Leer y convertir el segundo número.
                Console.Write("Ingresa el segundo número: ");
                float num2 = float.Parse(Console.ReadLine());

                //Crear una instancia de Numero con los números ingresados.
                numeros = new Numero(num1, num2);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                //Vuelve a pedir los números en caso de error.
                Console.WriteLine("No has introducido un valor numérico válido.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
                PedirNumeros();
            }
        }

        //Muestra opciones al usuario después de mostrar el resultado y permite realizar acciones adicionales.
        private void MenuPostResultado()
        {
            Thread.Sleep(1000);
            Console.WriteLine("¿Qué te gustaría hacer ahora?");
            Console.WriteLine("1. Realizar otra operación con los mismos números");
            Console.WriteLine("2. Ingresar números nuevos");
            Console.WriteLine("3. Salir del programa\n");
            Console.Write("Selecciona una opción: ");

            try
            {
                //Leer la opción seleccionada.
                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1)
                {
                    //Limpiar la consola para mostrar el menú nuevamente.
                    Console.Clear();
                }
                else if (opcion == 2)
                {
                    //Solicitar números nuevos.
                    Console.WriteLine();
                    PedirNumeros();
                    Console.Clear();
                }
                else if (opcion == 3)
                {
                    //Salir del programa.
                    Environment.Exit(0);
                }
                else
                {
                    //Vuelve a mostrar el menú si la opción no es válida.
                    Console.WriteLine("Opción no válida. Inténtalo nuevamente.\n");
                    MenuPostResultado();
                }
            }
            catch (Exception e)
            {
                //Volver a mostrar el menú en caso de error.
                Console.WriteLine("No has introducido un valor numérico válido.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
                MenuPostResultado();
            }
        }

        //Método que calcula y muestra el resultado de la suma de los números.
        private void Sumar()
        {
            float resultado = calculadora.Sumar(numeros);
            Console.WriteLine($"El resultado de la suma es: {resultado}\n");
        }

        //Método que calcula y muestra el resultado de la resta de los números.
        private void Restar()
        {
            float resultado = calculadora.Restar(numeros);
            Console.WriteLine($"El resultado de la resta es: {resultado}\n");
        }

        //Método que calcula y muestra el resultado de la multiplicación de los números.
        private void Multiplicar()
        {
            float resultado = calculadora.Multiplicar(numeros);
            Console.WriteLine($"El resultado de la multiplicación es: {resultado}\n");
        }

        //Método que calcula y muestra el resultado de la división de los números.
        private void Dividir()
        {
            float resultado = calculadora.Dividir(numeros);
            Console.WriteLine($"El resultado de la división es: {resultado}\n");
        }
    }
}
