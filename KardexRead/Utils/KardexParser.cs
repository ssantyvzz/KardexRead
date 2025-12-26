using iText.Kernel.Geom;
using KardexRead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace KardexRead.Utils
{
    public class KardexParser
    {
        public KardexData Parse(string rawText)
        {

            KardexData kardex = new KardexData();

            // EXTRAER DATOS DEL KARDEX
            kardex.Matricula = ExtractMatricula(rawText);
            kardex.Nombre = ExtractNombre(rawText);
            kardex.Grupo = ExtractGrupo(rawText);
            kardex.Carrera = ExtractCarrera(rawText);
            kardex.Promedio = ExtractPromedio(rawText);
            kardex.CreditosPromovidos = ExtractCreditosPromovidos(rawText);
            kardex.CreditosPorcentaje = ExtractCreditosPorcentaje(rawText);

            kardex.Asignaturas = ExtractAsignaturas(rawText);

            return kardex;
        }

        private string ExtractMatricula(string text)
        {
            var match = Regex.Match(text, @"\b\d{8}\b");
            return match.Success ? match.Value : string.Empty;
        }

        private string ExtractNombre(string text)
        {
            var match = Regex.Match(
                text,
                @"\b\d{8}\s+([A-ZÁÉÍÓÚÑ\s]+?)(?=\s+[A-Z]{3,5}\/\d{1,2})"
            );

            return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
        }

        private string ExtractGrupo(string text)
        {
            var match = Regex.Match(text, @"\b(?<grupo>[A-Z]{3,5})\/\d{1,2}\b");
            return match.Success ? match.Groups["grupo"].Value : string.Empty;
        }

        private string ExtractCarrera(string text)
        {
            // BUSCAR EL PATRÓN DE CARRERA
            var match = Regex.Match(
                text,
                @"[A-Z]{3,5}/\d{1,2}\s+(?<carrera>.+?)(?=\s+CVEPER|\s+TR|\s+CVEMAT|\r|\n|$)",
                RegexOptions.IgnoreCase
            );

            if (match.Success)
            {
                string carreraCompleta = match.Groups["carrera"].Value.Trim();

                // BUSCAR EL PRIMER GUION O LA PALABRA "Área"
                if (carreraCompleta.Contains("-"))
                {
                    return carreraCompleta.Split('-')[0].Trim();
                }
                if (carreraCompleta.Contains("Área"))
                {
                    int index = carreraCompleta.IndexOf("Área", StringComparison.OrdinalIgnoreCase);
                    return carreraCompleta.Substring(0, index).Trim();
                }

                return carreraCompleta;
            }

            return string.Empty;
        }

        private string ExtractPromedio(string text)
        {
            var match = Regex.Match(
                text,
                @"Promedio General:\s*([\d\.]+)"
            );

            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private string ExtractCreditosPromovidos(string text)
        {
            var match = Regex.Match(
                text,
                @"Totales.*?%(\d{2,3})[\d\.]*\s*%"
            );

            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private string ExtractCreditosPorcentaje(string text)
        {
            var match = Regex.Match(
                text,
                @"Totales.*?\d{2,3}\.\d{2}\s*%\d+(\d{2}\.\d{2}\s*%)"
            );

            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private List<AsignaturaData> ExtractAsignaturas(string text)
        {
            List<AsignaturaData> listaAsignaturas = new List<AsignaturaData>();
            string tiposExamen = @"ORD|EXT|ESP|CON|EQU|REV|MOD|ADI|SS|UBC|ERP";

            string pattern = $@"^(?<ciclo>\d{{6}})\s*(?<semestre>\d{{1,2}})?\s*(?<clave>[A-Z]{{1,5}}[0-9A-Z]+)\s+(?<nombre>.+?)\s+(?<acta>\d{{11}})\s+(?<calif>AC|NA|NP|\d{{1,2}}(?:\.\d)?)\s+(?<examen>{tiposExamen})\s+(?<promo>AC|NA|NP)\s+(?<creditos>\d{{1,2}})$";

            var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string tipoFormacionActual = "General";

            foreach (var rawLine in lines)
            {
                var line = rawLine.Replace('\u00A0', ' ').Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                // ACTUALIZAR TIPO DE FORMACIÓN
                if (line.Contains("Formación Genérica Básica")) { tipoFormacionActual = "Formación Genérica Básica"; continue; }
                if (line.Contains("Formación Disciplinar")) { tipoFormacionActual = "Formación Disciplinar"; continue; }
                if (line.Contains("Optativas Disciplinares")) { tipoFormacionActual = "Optativas Disciplinares"; continue; }
                if (line.Contains("Tópicos Avanzados")) { tipoFormacionActual = "Tópicos Avanzados"; continue; }
                if (line.Contains("Optativas Profesionales")) { tipoFormacionActual = "Optativas Profesionales"; continue; }
                if (line.Contains("Actividades para El Desarrollo Integral")) { tipoFormacionActual = "Actividades para El Desarrollo Integral"; continue; }
                if (line.Contains("PIFLEX")) { tipoFormacionActual = "PIFLEX"; continue; }

                Match match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    listaAsignaturas.Add(new AsignaturaData
                    {
                        TipoFormacion = tipoFormacionActual,
                        SemestreAsignatura = match.Groups["semestre"]?.Value ?? "",
                        Asignatura = match.Groups["nombre"].Value.Trim(),
                        NumeroActa = match.Groups["acta"].Value,
                        Calificacion = match.Groups["calif"].Value,
                        TipoExamen = match.Groups["examen"].Value,
                        ClavePromocion = match.Groups["promo"].Value,
                        CreditosAsignatura = match.Groups["creditos"].Value
                    });
                }
            }

            return listaAsignaturas;
        }

    }
}
