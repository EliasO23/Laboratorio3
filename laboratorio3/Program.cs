// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using laboratorio3;
using System.ComponentModel;

Context db = new Context();

Console.WriteLine("\nBienvenido a Facultades");

Console.WriteLine("\nInformacion de las facultades");
Console.WriteLine("------------------------------------");
Console.WriteLine("  Id   Nombre     Coordinador");
Console.WriteLine("------------------------------------");
foreach (var item in db.facultades)
{
    Console.WriteLine($"  {item.id}    {item.nombre}    {item.coordinador}\n       Asignaturas: {item.asignaturas}  Docentes: {item.docentes}");
}

Console.WriteLine("\nPresione ENTER para continuar: ");
var espera = Console.ReadLine();


Console.WriteLine("\nActualizacion de Registro-Facultades");
Console.WriteLine("------------------------------------------");
Console.WriteLine("Ingrese el ID de la facultad a actualizar");
int id = Convert.ToInt32(Console.ReadLine());
var registro = db.facultades.FirstOrDefault(x => x.id == id);

if (registro == null)
{
    Console.WriteLine("El registro no existe");
}
else
{
    Console.WriteLine("\nPara actualizar coloca:       ");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("   1. Nombre   \n   2. Coordinador   \n   3. Asignaturas   \n   4. Docentes");
    Console.WriteLine("-----------------------------------");
    Console.Write("- ¿Que desea actualizar? ");
    int desicion = Convert.ToInt32(Console.ReadLine());

    if (desicion <= 0 || desicion >= 5)
    {
        Console.WriteLine("Opcion Invalidad");
    }
    else
    {
        switch (desicion)
        {
            case 1:
                Console.WriteLine("Ingrese el nombre de la facultad: ");
                registro.nombre = Console.ReadLine();
                break;
            case 2:
                Console.WriteLine($"Ingrese el nombre del encargado de {registro.nombre}");
                registro.coordinador = Console.ReadLine();
                break;
            case 3:
                Console.WriteLine($"Ingrese la cantidad de asignaturas para la facultad de {registro.nombre}");
                registro.asignaturas = Convert.ToInt32(Console.ReadLine());
                break;
            case 4:
                Console.WriteLine($"Ingrese la cantidad de docentes para la facultad de {registro.nombre}");
                break;
        }
        db.Update(registro);
        db.SaveChanges();
        Console.WriteLine("\n - Actualizacion correcta");
    }
}

Console.WriteLine("\nPresione ENTER para continuar: ");
var espera1 = Console.ReadLine();

Console.WriteLine("\nAgregar nuevo Registro-Facultades");
Console.WriteLine("------------------------------------------");
facultades Facultades = new facultades();

Console.WriteLine("Ingrese el nombre de la facultad:");
Facultades.nombre = Console.ReadLine();
Console.WriteLine("Ingrese el encargado de la facultad: ");
Facultades.coordinador = Console.ReadLine();
Console.WriteLine("Ingrese la cantidad de asignaturas que tiene la facultad");
Facultades.asignaturas = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ingrese la cantidad de docentes que tiene la facultad:");
Facultades.docentes = Convert.ToInt32(Console.ReadLine());

db.Add(Facultades);
db.SaveChanges();
Console.WriteLine("\n - El registro se agrego correctamente ");

Console.WriteLine("\nPresione ENTER para continuar: ");
var espera2 = Console.ReadLine();

foreach (var item in db.facultades)
{
    Console.WriteLine($"  {item.id}    {item.nombre}    {item.coordinador}\n       Asignaturas: {item.asignaturas}  Docentes: {item.docentes}");
}

