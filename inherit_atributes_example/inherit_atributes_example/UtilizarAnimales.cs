using inherit_atributes_example.ModelosPolimorfismo;
using System;
using System.Collections.Generic;
using System.Text;

namespace inherit_atributes_example
{
    class UtilizarAnimales
    {
        private static UtilizarAnimales _utilizarAnimales;
        public static UtilizarAnimales CrearInstanciaCrearAlumnoSiNoExiste()
        {
            if (_utilizarAnimales == null)
            {
                _utilizarAnimales = new UtilizarAnimales();
            }

            return _utilizarAnimales;
        }

        private UtilizarAnimales()
        {
            CrearEjemploAnimalAcuatico();
            CrearEjemploAnimalTerrestre();
        }

        private void CrearEjemploAnimalAcuatico()
        {
            var animalAcuatico = new AnimalAcuatico(null, null);
            Console.WriteLine(animalAcuatico.Respirar());
            Console.WriteLine(animalAcuatico.Tipo);
        }

        private void CrearEjemploAnimalTerrestre()
        {
            var animalTerrestre = new AnimalTerrestre(null, null);
            Console.WriteLine(animalTerrestre.Respirar());
        }


    }
}
