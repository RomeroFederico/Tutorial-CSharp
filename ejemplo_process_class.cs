using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

// Fuente: https://csharp.net-tutorials.com/misc/starting-applications-with-the-process-class

namespace LinqTakeSkip1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Press any key to run CMD...");
      Console.ReadKey();

      ProcessStartInfo processStartInfo = new ProcessStartInfo();
      processStartInfo.FileName = @"C:\Windows\system32\cmd.exe";   // Abre la consola.
      processStartInfo.Arguments = "/c date /t";                    // Le pasamos como argumento un programa directamente. 

      processStartInfo.CreateNoWindow = true;                       // No crea una ventana nueva.
      processStartInfo.UseShellExecute = false;                     // No utiliza Shell.
      processStartInfo.RedirectStandardOutput = true;               // La salida de esta aplicacion sera capturada en esta.

      Process process = new Process();
      process.StartInfo = processStartInfo;
      process.Start();                                              // Comenzamos la aplicacion.

      string output = process.StandardOutput.ReadToEnd();           // Recibimos la salida de la app.
      process.WaitForExit();                                        // Esperamos a que se cierre la

      Console.WriteLine("Current date (received from CMD):");
      Console.Write(output);                                        // Imprimimos el resultado.
    }
  }
}