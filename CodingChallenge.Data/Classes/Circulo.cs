using CodingChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal diametro)
        {
            if (diametro <= 0)
                throw new ArgumentException();
            _radio = diametro / 2;
        }

        public override decimal CalculateArea()
        {
            return (decimal)Math.PI * _radio * _radio;
        }

        public override decimal CalculatePerimeter()
        {
            return 2 * (decimal)Math.PI * _radio;
        }

        public override string GetQuantityDescription(List<FormaGeometrica> shapes)
        {
            if (!shapes.Any()) return string.Empty;
            return $"{shapes.Count} {(shapes.Count == 1 ? Messages.Circle : Messages.Circles)}";
        }
    }
}
