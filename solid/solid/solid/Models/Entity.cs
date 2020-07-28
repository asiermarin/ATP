using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Models
{
    public class Entity
    {
        public Entity(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height { get; set; }

        public double Width { get; set; }
    }
}
