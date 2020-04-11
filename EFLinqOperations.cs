using ConsoleEFLINQToEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFLINQToEntities
{
    public class EFLinqOperations
    {
        public EFLinqOperations()
        {

        }

        public int CrearEstudiante(Estudiante entity)
        {
            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    db.Estudiante.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 1;
        }

        public int CrearCurso(Curso entity)
        {
            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    db.Curso.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 1;
        }

        public int CrearMatricula(Matricula entity)
        {
            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    db.Matricula.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 1;
        }

        public List<Estudiante> ConsultarEstudiantes()
        {
            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    return db.Estudiante.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public List<Curso> ConsultarCursos()
        {
            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    return db.Curso.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public Estudiante ConsultarEstudiantePorIdentificacion(string Identificacion)
        {
            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    return db.Estudiante.Where(o => o.Identificacion.Equals(Identificacion)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public List<EstudianteDTO> ConsultarEstudiantesPorCurso(int IdCurso)
        {
            List<EstudianteDTO> estudiantes = new List<EstudianteDTO>();

            try
            {
                using (NotasDBEntities db = new NotasDBEntities())
                {
                    var query = db.Estudiante
                          .Join(db.Matricula,
                                e => e.IdEstudiante,
                                m => m.IdEstudiante,
                                (e, m) => new {
                                    e.PrimerNombre, e.SegundoNombre, e.PrimerApellido, e.SegundoApellido, m.Anio, m.IdCurso
                                }
                          ).Join(db.Curso,
                                 m => m.IdCurso,
                                 c => c.IdCurso,
                                 (m, c) => new {
                                     m.PrimerNombre, m.SegundoNombre, m.PrimerApellido, m.SegundoApellido, m.Anio, m.IdCurso,
                                     NombreEstudiante = m.PrimerNombre
                                                + (string.IsNullOrEmpty(m.SegundoNombre) ? string.Empty : " " + m.SegundoNombre)
                                                + " " + m.PrimerApellido
                                                + (string.IsNullOrEmpty(m.SegundoApellido) ? string.Empty : " " + m.SegundoApellido),
                                     NombreCurso = c.Descripcion
                                 }
                         ).Where(o => o.IdCurso == IdCurso);

                    foreach (var item in query)
                    {
                        estudiantes.Add(new EstudianteDTO()
                        {
                            Anio = item.Anio,
                            IdCurso = item.IdCurso,
                            NombreCurso = item.NombreCurso,
                            NombreEstudiante = item.NombreEstudiante
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
