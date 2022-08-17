using System.Diagnostics; // Para la clase process.

// ### Random class ###

Random random = new Random();                             // Nueva instancia de la clase Random.
Console.WriteLine("A random number: " + random.Next());   // Obtiene un numero random (INT) (0 - INT MAX_VALUE = 2147483647).
Console.WriteLine("A random number with decimals: " + random.NextDouble()); // Obtiene entre (DOUBLE) (0 >= X < 1).
// Se puede establecer el rango de resultados.
Console.WriteLine("A random number between 1 and 100: " + random.Next(1, 101)); // Obtiene entre 1 (incluyente) y 101 (excluyente).
// Se puede establecer la semilla.
Random randomWithEstablishedSeed = new Random(1000);
for(int i = 0; i < 5; i++)
  Console.WriteLine("A random number between 1 and 100: " + random.Next(1, 101));

/*
A random number between 1 and 100: 16
A random number between 1 and 100: 24
A random number between 1 and 100: 76
A random number between 1 and 100: 1
A random number between 1 and 100: 70
*/

// Bajo las mismas condiciones (codigo), una semilla producira siempre los mismos resutados.
// Se puede utilizar la clase RNGCryptoServiceProvider para numeros aleatorios mas seguros (como hashes o passwords).

// ### Process class ###

// Es posible ejecutar otras aplicaciones desde una ya en ejecucion.
Process.Start("https://www.google.com/"); // Puede ser una url o una ruta a una aplicacion local.
Process.Start(@"C:\Windows\notepad.exe");
// Basicamente, la clase Process le avista al OS de que tiene que correr la ruta pasada como argumento.
// Si el sistema encuentra que la ruta pasada es soportada, la ejecutara como pueda, ya sea abriendola (si se trata de una aplicacion),
// o abriendo otro programa que pueda manejar lo ingresado.
Process.Start(@"C:\Windows\notepad.exe", @"C:\Windows\win.ini");
// Es posible pasar otros argumentos al metodo, en este caso es la ruta al achivo que queremos abrir con el bloc de nota.

// ProcessStartInfo: Es una clase que nos ayuda a administrar mejor la apertura de procesos.

ProcessStartInfo processStartInfo = new ProcessStartInfo(); // Instancia de la clase.
processStartInfo.FileName = @"C:\Windows\notepad.exe";      // La ruta del archivo a ejecutar.
processStartInfo.Arguments = @"C:\Windows\win.ini";         // Los argumentos que queremos pasar.

// Podemos establecer si queremos que la venta este minimizada, maximizada, oculta o normal.
processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
// Si no queremos que abra una nueva ventana. NOTA: La aplicacion debe cerrarse por si misma o si no habra que cerrarla con Kill.
processStartInfo.CreateNoWindow = true;
// Si queremos que se abra con Shell.
// El valor por defecto es true con aplicaciones .NET Framework y false con aplicaciones .NET Core.
processStartInfo.UseShellExecute = true;
// Con UseShellExecute == true : Setea la locacion del ejecutable.
// Con UseShellExecute == false : El valor es aplicado al prcoceso que se abrio.
processStartInfo.WorkingDirectory = "./path";
// Permite redirigir la entrada, salida y errores al programa actual que abrio el proceso. Util con CreateNoWindow == true.
processStartInfo.RedirectStandardInput = true;
processStartInfo.RedirectStandardOutput = true;
processStartInfo.RedirectStandardError = true;

Process.Start(processStartInfo); //Simplemente pasamos como argumento la instancia a Process.Start().