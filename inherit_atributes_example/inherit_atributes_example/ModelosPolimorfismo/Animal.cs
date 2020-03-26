using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example.Modelos
{
    class Animal
    {
        public string Tipo {get; set;}
        protected string Raza { get; set; }

        public Animal (string tipo, string raza)
        {
            Tipo = tipo;
            Raza = raza;
        }

        protected static string CambiarTipo(string tipo)
        {
            if (tipo == "ballena")
            {
                tipo = "pez";
            }
            return tipo;
        }

        protected virtual string Moverse() 
        {
            return "me estoy moviendo";
        }

        public virtual string Respirar()
        {
            return "Animal que respira";
        }

    }
}
