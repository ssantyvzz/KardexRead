using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KardexRead.Models
{
    // DATOS GENERALES DEL ALUMNO
    public class KardexData
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public string Grupo { get; set; }
        public string Promedio { get; set; }
        public string CreditosPromovidos { get; set; }
        public string CreditosPorcentaje { get; set; }

        public List<AsignaturaData> Asignaturas { get; set; } = new List<AsignaturaData>();
    }

    // DATOS DE CADA ASIGNATURA
    public class AsignaturaData
    {
        public string TipoFormacion { get; set; }
        public string SemestreAsignatura { get; set; }
        public string Asignatura { get; set; }
        public string NumeroActa { get; set; }
        public string Calificacion { get; set; }
        public string TipoExamen { get; set; }
        public string ClavePromocion { get; set; }
        public string CreditosAsignatura { get; set; }
    }
}
