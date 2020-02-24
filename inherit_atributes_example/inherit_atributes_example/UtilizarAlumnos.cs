using inherit_atributes_example.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example
{
    class UtilizarAlumnos
    {
        private static UtilizarAlumnos _utilizarAlumnos;
        private List<Alumno> _listaAlum;
        public static UtilizarAlumnos CrearInstanciaCrearAlumnoSiNoExiste()
        {
            if (_utilizarAlumnos == null)
            {
                _utilizarAlumnos = new UtilizarAlumnos();
            }

            return _utilizarAlumnos;
        }

        public UtilizarAlumnos() 
        {
            _listaAlum = new List<Alumno>();
        }

        public void CrearAlumno()
        {
            List<int> listaNum;
            var alumno = new Alumno("2*B", "Matematicas", null , null, 19, listaNum);
            _listaAlum.Add(alumno);

            Console.WriteLine(_listaAlum.Count);
            Console.WriteLine(alumno.Apellido + " " + alumno.Nombre + " "+ alumno.Edad); //edad igual a 21
        }
    }
}
