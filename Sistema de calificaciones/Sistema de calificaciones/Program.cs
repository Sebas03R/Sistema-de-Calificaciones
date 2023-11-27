using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a la aplicación de calificaciones");

        Console.Write("Ingrese el nombre del curso: ");
        string nombreCurso = Console.ReadLine();

        Console.Write("Ingrese la cantidad de estudiantes: ");
        int cantidadEstudiantes = int.Parse(Console.ReadLine());

        string[] nombres = new string[cantidadEstudiantes];
        string[] apellidos = new string[cantidadEstudiantes];
        int[] calificaciones = new int[cantidadEstudiantes];

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.WriteLine($"\nIngrese información para el estudiante {i + 1}");

            Console.Write("Nombre: ");
            nombres[i] = Console.ReadLine();

            Console.Write("Apellido: ");
            apellidos[i] = Console.ReadLine();

            Console.Write("Calificación (0-100): ");
            calificaciones[i] = int.Parse(Console.ReadLine());

            if (calificaciones[i] < 0 || calificaciones[i] > 100)
            {
                Console.WriteLine("La calificación debe estar entre 0 y 100. Inténtelo de nuevo.");
            }
        }

        OrdenarPorCalificacion(nombres, apellidos, calificaciones, cantidadEstudiantes);
        Console.Clear();
        Console.WriteLine($"{nombreCurso.ToUpper()}");
        Console.WriteLine(new string('=', 52));
        Console.WriteLine($"{"Nombre",-15} | {"Apellido",-15} | {"Calificación",15}");
        ImprimirLinea();

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.WriteLine($"{nombres[i],-15} | {apellidos[i],-15} | {calificaciones[i],15}");
        }


        double promedio = CalcularPromedio(calificaciones, cantidadEstudiantes);

        Console.WriteLine($"{" ",-15} | {" ",-15} | {" ",-15}");

        Console.WriteLine($"{"Promedio",-15} | {" ",-15} | {promedio,15:F2}");

        ImprimirLinea();
    }

    static void ImprimirLinea()
    {
        Console.WriteLine(new string('-', 52));
    }

    static void OrdenarPorCalificacion(string[] nombres, string[] apellidos, int[] calificaciones, int n)
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (calificaciones[j] > calificaciones[j + 1])
                {
                    string tempNombre = nombres[j];
                    nombres[j] = nombres[j + 1];
                    nombres[j + 1] = tempNombre;

                    string tempApellido = apellidos[j];
                    apellidos[j] = apellidos[j + 1];
                    apellidos[j + 1] = tempApellido;

                    int tempCalificacion = calificaciones[j];
                    calificaciones[j] = calificaciones[j + 1];
                    calificaciones[j + 1] = tempCalificacion;
                }
            }
        }
    }

    static double CalcularPromedio(int[] calificaciones, int n)
    {
        int suma = 0;
        for (int i = 0; i < n; i++)
        {
            suma += calificaciones[i];
        }

        return Math.Round((double)suma / n, 2);
    }
}
