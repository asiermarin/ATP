using inherit_atributes_example.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example.ModelosPolimorfismo
{
    class AnimalTerrestre : Animal
    {
        public AnimalTerrestre(string tipo, string raza) :  base(CambiarTipo(tipo), raza)
        {
            tipo = "gorila";       // no se va a ejecutar, antes va a la clase padre
            raza = "gorila gris";
        }

        protected override string Moverse()    // Si el padre es protected los demas también!
        {
            return "Animal terrestre anda";
        }

        public override string Respirar()
        {
            return "Animal terrestre respira al aire libre";
        }

        public virtual void Andar()
        {
            Console.WriteLine("Un animal anda");
        }
    }
}
