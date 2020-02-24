using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example.Modelos
{
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public List<int> _listaNum;

        public Persona ()
        {
            
        }

        public Persona (string nombre, string apellido, int edad, List<int> numeros)
        {
            nombre = "Asier";
            apellido = "Marin";

            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            _listaNum = numeros;
        }

        protected static int SumarEdad(int edad)
        {
            return  edad + 2;
        }

        protected static List<int> CrearLista(List<int> numeros)
        {
            return numeros = new List<int>();
        }
    }
}
