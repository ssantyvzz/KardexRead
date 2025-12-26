using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using KardexRead.Models;
using System.IO;
using System.Drawing;

namespace KardexRead.Services
{
    public class ExcelExportService
    {
        public void ExportKardexToExcel(KardexData data, string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("KardexRead");

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Kardex Académico");

                #region ESTILOS DE LA HOJA
                // ESTILO DE TITULO
                sheet.Cells["A1:H2"].Merge = true;
                var tituloPrincipal = sheet.Cells["A1"];
                tituloPrincipal.Style.Font.Size = 18;
                tituloPrincipal.Style.Font.Bold = true;
                tituloPrincipal.Style.Font.Name = "Aptos Display";

                tituloPrincipal.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                tituloPrincipal.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                tituloPrincipal.Style.Fill.PatternType = ExcelFillStyle.Solid;
                tituloPrincipal.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(150, 23, 73));

                // ESTILOS DE LOS DATOS DEL ALUMNO
                var datosAlumno = sheet.Cells["A3:B5,A3:H6"].Style;
                datosAlumno.Font.Bold = true;
                datosAlumno.Font.Size = 14;

                var etiquetas = sheet.Cells["B3:B5,D3:D5"].Style;
                etiquetas.Font.Bold = false;
                etiquetas.Font.Size = 14;
                #endregion

                #region INSERTAR ETIQUETAS Y DATOS DEL ENCABEZADO
                // ENCABEZADO DEL REPORTE
                sheet.Cells["A1"].Value = "REPORTE DE KARDEX ACADÉMICO";
                sheet.Cells["B3"].Value = "Alumno:";
                sheet.Cells["B4"].Value = "Matrícula:";
                sheet.Cells["B5"].Value = "Carrera:";
                sheet.Cells["D3"].Value = "Promedio:";
                sheet.Cells["D4"].Value = "Creditos:";
                sheet.Cells["D5"].Value = "Avance:";

                // DATOS DE ALUMNO EN ENCABEZADO
                sheet.Cells["C3"].Value = data.Nombre;
                sheet.Cells["C5"].Value = data.Carrera;
                #endregion

                #region CONVERTIR DATOS DE ALUMNO A NUMERICO
                // CONVERITR MATRICULA A NUMERICO
                if (int.TryParse(data.Matricula, out int matriculaNum))
                {
                    sheet.Cells["C4"].Value = matriculaNum;
                    sheet.Cells["C4"].Style.Numberformat.Format = "0";
                    sheet.Cells["C4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }

                // CONVERTIR PROMEDIO A NUMERICO
                if (double.TryParse(data.Promedio, out double promNum))
                {
                    sheet.Cells["E3"].Value = promNum;
                    sheet.Cells["E3"].Style.Numberformat.Format = "0.00";
                }

                // CONVERITIR CREDITOS A NUMERICO
                if (int.TryParse(data.CreditosPromovidos, out int creditosNum))
                {
                    sheet.Cells["E4"].Value = creditosNum;
                    sheet.Cells["E4"].Style.Numberformat.Format = "0";
                }

                // CONVERTIR PORCENTAJE D CREDITOS A NUMERICO
                string cleanPorcentaje = data.CreditosPorcentaje.Replace("%", "").Trim();
                if (double.TryParse(cleanPorcentaje, out double percNum))
                {
                    sheet.Cells["E5"].Value = percNum / 100;
                    sheet.Cells["E5"].Style.Numberformat.Format = "0.00%";
                }
                #endregion

                #region CREACIÓN DE LA TABLA DE ASIGNATURAS
                // CREAR TABLA DE ASIGNATURAS
                int startRow = 7;
                string[] headers = { "Tipo de Formación", "Semestre", "Asignatura", "No. Acta", "Calificación", "Examen", "Promoción", "Créditos" };

                // FORMATO DE ENCABEZADOS DE LA TABLA
                for (int i = 0; i < headers.Length; i++)
                {
                    var header = sheet.Cells[startRow, i + 1];
                    header.Value = headers[i];
                    header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    header.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(150, 23, 73));
                    header.Style.Font.Color.SetColor(Color.White);
                    header.Style.Font.Bold = true;
                }
                #endregion

                #region INSERTAR DATOS DE ASIGNATURAS  
                // INSERTAR DATOS DE ASIGNATURAS
                int currentRow = startRow + 1;
                foreach (var m in data.Asignaturas)
                {
                    sheet.Cells[currentRow, 1].Value = m.TipoFormacion;

                    // CONVERTIR SEMESTRE EN DATO NUMERICO
                    if (int.TryParse(m.SemestreAsignatura, out int semestreNum))
                    {
                        sheet.Cells[currentRow, 2].Value = semestreNum;
                        sheet.Cells[currentRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    } else
                    { 
                        sheet.Cells[currentRow, 2].Value = m.SemestreAsignatura;
                    }
                        
                    sheet.Cells[currentRow, 3].Value = m.Asignatura;

                    // CONVERTIR ACTA EN DATO NUMERICO
                    if (long.TryParse(m.NumeroActa, out long actaNum))
                    {
                        sheet.Cells[currentRow, 4].Value = actaNum;
                        sheet.Cells[currentRow, 4].Style.Numberformat.Format = "0";
                        sheet.Cells[currentRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    } else {
                        sheet.Cells[currentRow, 4].Value = m.NumeroActa;
                    }

                    // CONVERTIR CALIFICACION EN DATO NUMERICO
                    if (double.TryParse(m.Calificacion, out double califNum))
                    {
                        sheet.Cells[currentRow, 5].Value = califNum;
                        sheet.Cells[currentRow, 5].Style.Numberformat.Format = "0.0";
                    }
                    else
                    {
                        sheet.Cells[currentRow, 5].Value = m.Calificacion;
                        sheet.Cells[currentRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    sheet.Cells[currentRow, 6].Value = m.TipoExamen;
                    sheet.Cells[currentRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    sheet.Cells[currentRow, 7].Value = m.ClavePromocion;
                    sheet.Cells[currentRow, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // CONVERTIR CREDITOS EN DATO NUMERICO
                    if (int.TryParse(m.CreditosAsignatura, out int creditosNumeric))
                    {
                        sheet.Cells[currentRow, 8].Value = creditosNumeric;
                        sheet.Cells[currentRow, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    else
                    {
                        sheet.Cells[currentRow, 8].Value = m.CreditosAsignatura;
                    }

                    // FORMATO DE FILA PARA ASIGNATURAS NO ACREDITADAS
                    if (m.ClavePromocion == "NA" || m.ClavePromocion == "NP")
                    {
                        using (var range = sheet.Cells[currentRow, 1, currentRow, 8])
                        {
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 230, 230));
                            range.Style.Font.Color.SetColor(Color.DarkRed);

                        }
                    }

                    currentRow++;
                }
                #endregion

                #region ESTILOS DE LA TABLA FINAL
                // BORDES DE LA TABLA
                var tablaCompleta = sheet.Cells[8,1, currentRow - 1, headers.Length];
                tablaCompleta.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                tablaCompleta.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                tablaCompleta.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                tablaCompleta.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                // AJUSTE DE ANCHO DE COLUMNAS
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                #endregion

                // GUARDAR EL ARCHIVO EXCEL
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}
