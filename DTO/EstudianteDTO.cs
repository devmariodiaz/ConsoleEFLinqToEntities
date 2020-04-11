using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFLINQToEntities.DTO
{
    public class EstudianteDTO
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Anio { get; set; }
        public int IdCurso { get; set; }
        public string NombreEstudiante { get; set; }
        public string NombreCurso { get; set; }
    }
}
