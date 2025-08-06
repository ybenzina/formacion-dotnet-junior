using MyApp.Core.Servicios;

var servicio = new ServicioSaludo();
Console.WriteLine("¿Cual es tu nombre?");
var nombre = Console.ReadLine();
Console.WriteLine(servicio.Saludar(nombre));

