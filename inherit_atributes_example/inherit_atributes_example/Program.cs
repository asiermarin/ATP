using inherit_atributes_example.Modelos;
using System;

namespace inherit_atributes_example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Persona.CrearInstnciaPersonaSiNoExiste();
            var obj = UtilizarAlumnos.CrearInstanciaCrearAlumnoSiNoExiste();
            obj.CrearAlumno();


        }
    }
}
