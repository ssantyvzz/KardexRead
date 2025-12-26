using KardexRead.Utils;
using KardexRead.Models;
using KardexRead.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KardexRead
{
    public partial class KardexReader : Form
    {
        public KardexReader()
        {
            InitializeComponent();
        }

        private KardexData datosKardex;

        private void btnAgregarPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                Title = "Selecciona el Kardex"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            PdfReaderService pdfService = new PdfReaderService();
            KardexParser parser = new KardexParser();

            string rawText = pdfService.ReadPdf(ofd.FileName);

            // DEVOLVER LOS DATOS PARSEADOS
            datosKardex = parser.Parse(rawText);

            // ACTUALIZAR LA INTERFAZ
            ActualizarEncabezado(datosKardex);
            BindGrid(datosKardex.Asignaturas);
        }

        private void ActualizarEncabezado(KardexData data)
        {
            lblNombre.Text = data.Nombre;
            lblMatricula.Text = data.Matricula;
            lblCarrera.Text = data.Carrera;
            lblPromedio.Text = data.Promedio;
            lblCreditosPromovidos.Text = data.CreditosPromovidos;
            lblPorcentaje.Text = data.CreditosPorcentaje;
        }

        private void BindGrid(List<AsignaturaData> asignaturas)
        {
            dgvKardex.DataSource = null;
            dgvKardex.DataSource = asignaturas;

            if (dgvKardex.ColumnCount > 0)
            {
                // AJUSTAR COLUMNAS AL CONTENIDO
                dgvKardex.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                // ENCABEZADOS
                if (dgvKardex.Columns["TipoFormacion"] != null)
                    dgvKardex.Columns["TipoFormacion"].HeaderText = "Tipo de Formación";

                if (dgvKardex.Columns["Asignatura"] != null)
                    dgvKardex.Columns["Asignatura"].HeaderText = "Asignatura";

                if (dgvKardex.Columns["SemestreAsignatura"] != null)
                    dgvKardex.Columns["SemestreAsignatura"].HeaderText = "Semestre";

                if (dgvKardex.Columns["NumeroActa"] != null)
                    dgvKardex.Columns["NumeroActa"].HeaderText = "No. Acta";

                if (dgvKardex.Columns["Calificacion"] != null)
                    dgvKardex.Columns["Calificacion"].HeaderText = "Calificación";

                if (dgvKardex.Columns["TipoExamen"] != null)
                    dgvKardex.Columns["TipoExamen"].HeaderText = "Examen";

                if (dgvKardex.Columns["ClavePromocion"] != null)
                    dgvKardex.Columns["ClavePromocion"].HeaderText = "Promoción";

                if (dgvKardex.Columns["CreditosAsignatura"] != null)
                    dgvKardex.Columns["CreditosAsignatura"].HeaderText = "Créditos";
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // VERIFICAR DATOS CARGADOS
            if (datosKardex == null || datosKardex.Asignaturas.Count == 0)
            {
                MessageBox.Show("No hay datos cargados para exportar. Por favor, selecciona un PDF primero.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CONFIGURAR DIALOGO DE GUARDADO
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
                sfd.Title = "Guardar Kardex en Excel";
                sfd.FileName = $"Kardex_{datosKardex.Matricula}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // CAMBIO DE CURSOR A ESPERA
                        Cursor.Current = Cursors.WaitCursor;

                        // INICIAR EXPORTACIÓN
                        ExcelExportService excelService = new ExcelExportService();
                        excelService.ExportKardexToExcel(datosKardex, sfd.FileName);

                        // NOTIFICAR ÉXITO
                        MessageBox.Show("El archivo Excel se ha generado correctamente.",
                                        "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ABRIR EL ARCHIVO EXPORTADO
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        // ERROR DE ACCESO AL ARCHIVO
                        MessageBox.Show("No se pudo guardar el archivo. Asegúrate de que no esté abierto en Excel.\n\nDetalles: " + ex.Message,
                                        "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al exportar: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // RESTAURAR CURSOR
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
    }
}
