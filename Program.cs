using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFLINQToEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            EFLinqOperations operations = new EFLinqOperations();
            int o = 0;
            
            while(o != -1)
            {
                Console.WriteLine("1. Crear Curso");
                Console.WriteLine("2. Consultar todos los estudiantes");
                // Console.WriteLine("");
                Console.Write("Seleccione una opción: ");
                //o = int.Parse(string.IsNullOrEmpty(Console.ReadLine().ToString()) ? "0" : Console.ReadLine().ToString());
                //o = int.Parse(Console.ReadLine().ToString());

                string input = Console.ReadLine().ToString();

                if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrEmpty(input))
                {
                    o = int.Parse(input);
                    switch (o)
                    {
                        case 1:

                            Curso curso = new Curso();

                            Console.WriteLine("::::::::::::::::::::::::::");
                            Console.WriteLine("Crear Curso");
                            Console.WriteLine("::::::::::::::::::::::::::");

                            Console.Write("Grado: ");
                            curso.NumGrado = int.Parse(Console.ReadLine().ToString());
                            Console.Write("Descripción del Curso: ");
                            curso.Descripcion = Console.ReadLine().ToString();
                            Console.Write("Activo (S/N):");
                            curso.Activo = Console.ReadLine().ToString();

                            operations.CrearCurso(curso);
                            Console.Clear();

                            List<Curso> cursos = operations.ConsultarCursos();
                            Console.WriteLine($"Cantidad: {cursos.Count}");
                            Console.WriteLine("::::::::::::::::::::::::::");
                            Console.WriteLine("Listado de estudiantes");
                            Console.WriteLine("::::::::::::::::::::::::::");
                            foreach (var item in cursos)
                            {
                                Console.WriteLine($"{item.Descripcion}, Activo: {item.Activo}");
                                Console.WriteLine("--------------------------------------------------");
                            }

                            break;
                        case 2:
                            List<Estudiante> estudiantes = operations.ConsultarEstudiantes();
                            Console.WriteLine($"Cantidad: {estudiantes.Count}");
                            Console.WriteLine("::::::::::::::::::::::::::");
                            Console.WriteLine("Listado de estudiantes");
                            Console.WriteLine("::::::::::::::::::::::::::");
                            foreach (var item in estudiantes)
                            {
                                Console.WriteLine($"{item.Identificacion} {item.PrimerNombre} {item.SegundoNombre} {item.PrimerApellido} {item.SegundoApellido}");
                                Console.WriteLine("--------------------------------------------------");
                            }

                            break;
                    }

                    Console.WriteLine("Digite <ENTER> para continuar:");
                    o = int.Parse(Console.ReadLine().ToString().Equals(string.Empty) ? "0" : Console.ReadLine().ToString());
                }

                Console.Clear();
            }
        }
    }
}
