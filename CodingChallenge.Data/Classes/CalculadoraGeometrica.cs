using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Extensions;
using CodingChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data
{
    public class CalculadoraGeometrica
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

    }
}
