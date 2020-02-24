using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example.Modelos
{
    class Alumno : Persona
    {
        public string Curso { get; set; }
        public string Asignatura { get; set; }

        public Alumno(string curso, string asignatura, string nombre, string apellido, int edad, List<int> listaNum) : base(nombre, apellido, SumarEdad(edad), CrearLista(listaNum))
        {
            Curso = curso;
            Asignatura = asignatura;
        }

        public Alumno()
        {
                
        }
    }
}
