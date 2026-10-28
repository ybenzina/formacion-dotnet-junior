using AsyncLib;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Demostración de Operaciones Asíncronas y Cancelación\n");

        var operaciones = new OperacionesAsync();
        
        // Demostración 1: Operación larga que completa exitosamente
        Console.WriteLine("1. Operación larga sin cancelación (2 segundos):");
        await operaciones.RealizarOperacionLargaAsync(2000);
        Console.WriteLine("\nLog de la operación:");
        Console.WriteLine(operaciones.LogOperaciones);
        
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
        
        // Demostración 2: Operación larga que se cancela
        Console.WriteLine("\n2. Operación larga con cancelación (se cancelará después de 1 segundo):");
        using var cts = new CancellationTokenSource();
        
        try
        {
            var operacionTask = operaciones.RealizarOperacionLargaAsync(5000, cts.Token);
            
            await Task.Delay(1000);
            Console.WriteLine("\n¡Cancelando operación!");
            cts.Cancel();
            
            await operacionTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nLa operación fue cancelada como se esperaba.");
        }
        
        Console.WriteLine("\nLog de la operación cancelada:");
        Console.WriteLine(operaciones.LogOperaciones);
        
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
        
        // Demostración 3: Procesamiento con recursos
        Console.WriteLine("\n3. Procesamiento con recursos:");
        try
        {
            var resultado = await operaciones.ProcesarConRecursosAsync();
            Console.WriteLine($"Resultado obtenido: {resultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        Console.WriteLine("\nLog del procesamiento:");
        Console.WriteLine(operaciones.LogOperaciones);
        
        Console.WriteLine("\nDemostración completada. Presiona Enter para salir...");
        Console.ReadLine();
    }
}
