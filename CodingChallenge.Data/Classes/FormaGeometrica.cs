/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Extensions;
using CodingChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public static string Imprimir(List<FormaGeometrica> formas, string idioma = "")
        {
            if (string.IsNullOrEmpty(idioma))
            {
                idioma = Languages.Ingles.GetCode();
            }

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(idioma);

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{Messages.EmptyListOfShapes}</h1>");

            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{Messages.ShapesReport}</h1>");

                foreach (var t in Type.GetTypeArray(formas.ToArray()).Distinct())
                {
                    var formasPorTipo = formas.Where(f => f.GetType() == t);
                    var area = formasPorTipo.Sum(fpt => fpt.CalculateArea());
                    var perimetro = formasPorTipo.Sum(fpt => fpt.CalculatePerimeter());
                    sb.Append(ObtenerLinea(formasPorTipo.FirstOrDefault().GetQuantityDescription(formasPorTipo.ToList()), area, perimetro));
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append($"{formas.Count} { Messages.Shapes.ToLower()} ");
                sb.Append($"{Messages.Perimeter} {formas.Sum(f => f.CalculatePerimeter()):#.##} ");
                sb.Append($"{Messages.Area} {formas.Sum(f => f.CalculateArea()):#.##}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(string cantidad, decimal area, decimal perimetro)
        {
            if (!string.IsNullOrEmpty(cantidad))
            {
                return $"{cantidad} | {Messages.Area} {area:#.##} | {Messages.Perimeter} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        public abstract decimal CalculateArea();

        public abstract decimal CalculatePerimeter();

        public abstract string GetQuantityDescription(List<FormaGeometrica> shapes);
    }
}
