using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                CalculadoraGeometrica.Imprimir(new List<FormaGeometrica>(), Languages.Castellano.GetCode()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                CalculadoraGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = CalculadoraGeometrica.Imprimir(cuadrados, Languages.Castellano.GetCode());

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = CalculadoraGeometrica.Imprimir(cuadrados, Languages.Ingles.GetCode());

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = CalculadoraGeometrica.Imprimir(formas, Languages.Ingles.GetCode());

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = CalculadoraGeometrica.Imprimir(formas, Languages.Castellano.GetCode());

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var formas = new List<FormaGeometrica>
            {
                new Rectangulo(2,4)
            };

            var resumen = CalculadoraGeometrica.Imprimir(formas, Languages.Castellano.GetCode());

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Rectángulo | Area 8 | Perimetro 12 <br/>TOTAL:<br/>1 formas Perimetro 12 Area 8",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapeciosPortugues()
        {
            var formas = new List<FormaGeometrica>
            {
                new Trapecio(1,1,2),
                new Trapecio(2,2,4),
                new Trapecio(3,3,6)
            };

            var resumen = CalculadoraGeometrica.Imprimir(formas, Languages.Portugues.GetCode());

            Assert.AreEqual(
                "<h1>Relatório de formas</h1>3 Trapézios | Área 21 | Perímetro 31,42 <br/>TOTAL:<br/>3 formas Perímetro 31,42 Área 21",
                resumen);
        }

        [TestCase]
        public void TestExceptionContructorTrapecio()
        {
            Assert.Throws<ArgumentException>(() => new Trapecio(1, 2, 1));
            Assert.Throws<ArgumentException>(() => new Trapecio(0, 1, 2));
            Assert.Throws<ArgumentException>(() => new Trapecio(1, -2, 1));
            Assert.Throws<ArgumentException>(() => new Trapecio(1, 2, -1));
        }

        [TestCase]
        public void TestExceptionContructorCuadrado()
        {
            Assert.Throws<ArgumentException>(() => new Cuadrado(0));
            Assert.Throws<ArgumentException>(() => new Cuadrado(-1));
        }

        [TestCase]
        public void TestExceptionContructorTrianguloEquilatero()
        {
            Assert.Throws<ArgumentException>(() => new TrianguloEquilatero(-1));
            Assert.Throws<ArgumentException>(() => new TrianguloEquilatero(0));
        }

        [TestCase]
        public void TestExceptionContructorCirculo()
        {
            Assert.Throws<ArgumentException>(() => new Circulo(-1));
            Assert.Throws<ArgumentException>(() => new Circulo(0));
        }

        [TestCase]
        public void TestExceptionContructorRectangulo()
        {
            Assert.Throws<ArgumentException>(() => new Rectangulo(-1, 2));
            Assert.Throws<ArgumentException>(() => new Rectangulo(1, 0));
        }
    }
}
