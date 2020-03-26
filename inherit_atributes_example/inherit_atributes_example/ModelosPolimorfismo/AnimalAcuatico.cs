using inherit_atributes_example.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example.ModelosPolimorfismo
{
    class AnimalAcuatico : Animal
    {
        public AnimalAcuatico(string tipo, string raza) : base(CambiarTipo(tipo),  raza)
        {
            tipo = "ballena";
            raza = "balleno blanco";
        }

        protected override string Moverse()    // Si el padre es protected los demas también!
        {
            return "Animal acuatico nada";
        }

        public override string Respirar()
        {
            return "Animal acuatico respira";
        }
    }
}
