using CodingChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        private readonly decimal _ladoUno;
        private readonly decimal _ladoDos;

        public Rectangulo(decimal ladoUno, decimal ladoDos)
        {
            if (ladoUno <= 0 || ladoDos <= 0)
                throw new ArgumentException();
            _ladoUno = ladoUno;
            _ladoDos = ladoDos;
        }

        public override decimal CalculateArea()
        {
            return _ladoUno * _ladoDos;
        }

        public override decimal CalculatePerimeter()
        {
            return 2 * _ladoUno + 2 * _ladoDos;
        }

        public override string GetQuantityDescription(List<FormaGeometrica> shapes)
        {
            return $"{shapes.Count} {(shapes.Count == 1 ? Messages.Rectangle : Messages.Rectangles)}";
        }
    }
}
