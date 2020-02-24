using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example.Modelos
{
    class Animal
    {
        public string Tipo {get; set;}
        public string Raza { get; set; }

        public Animal (string tipo, string raza)
        {
            Tipo = tipo;
            Raza = raza;
        }

        public void Moverse() { }

    }
}
