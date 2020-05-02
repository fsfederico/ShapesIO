using CodingChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _altura;
        private readonly decimal _baseMenor;
        private readonly decimal _baseMayor;

        public Trapecio(decimal altura, decimal baseMenor, decimal baseMayor)
        {
            if (altura <= 0 || baseMenor <= 0 || baseMayor <= 0 || baseMenor >= baseMayor)
                throw new ArgumentException();
            _altura = altura;
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
        }

        public override decimal CalculateArea()
        {
            return (_baseMayor + _baseMenor) * _altura / 2;
        }

        public override decimal CalculatePerimeter()
        {
            var a = (_baseMayor - _baseMenor) / 2;
            var diagonal = (decimal)Math.Sqrt((double)(a * a + (_altura * _altura)));
            return _baseMenor + _baseMayor + 2 * diagonal;
        }

        public override string GetQuantityDescription(List<FormaGeometrica> shapes)
        {
            return $"{shapes.Count} {(shapes.Count == 1 ? Messages.Trapeze : Messages.Trapezoids)}";
        }
    }
}
