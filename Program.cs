//P2_Calculadora_Programación Orientada a Objetos_Ingeniería en Software y Minería de Datos_ Manuel Sebastian De La Torre Sosa
namespace P2_Calculadora_MSDLTS
{
    //Clase principal que actúa como punto de entrada al programa.
    internal class Program 
    {
        static void Main(string[] args)
        {
            //Crea una instancia de InterfazUsuario y comienza la interacción con el usuario.
            InterfazUsuario interfaz = new InterfazUsuario();
            interfaz.Iniciar();
        }
    }
}
