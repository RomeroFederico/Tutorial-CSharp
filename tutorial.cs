using System;

namespace HelloWorld {
// Namespaces ===> Para modulos.

  class Program {

    static void Main(string[] args) {       // Main -> Ejecutar codigo principal.
      Console.WriteLine("Hello World!");    // Imprimir en la consola con salto de linea.
    }

    // Funciones Locales:
    static void FunctionInsideAFunction() { // Es posible definir funciones dentro de otras.
      string saludo = "Hola mundo!!!";

      Saludar();                            // La funcion puede declararse en cualquier lado.

      void Saludar() {                      // La misma no tiene modificadores.
        Console.WriteLine(saludo);          // Puede utilizar variables del contexto del metodo 'padre',
      }                                     // pero solo si se declararon previamente.

      static void SaludarConMetodoEstatico() { // Tambien pueden definirse como estaticas.
        Console.WriteLine("Hola Mundo!!!");    // La unica diferencia es que no pueden hacer referencia a variables fuera de su scope.
      }                                        // Util cuando no se quiere manipular indebidamente variables 'ajenas'.
    }

    static void TestVariables() {
      string stringVar = "Federico", apellido = "Romero";                     // Tipo_de_dato nombreDeVariable.
      Console.WriteLine("Hola, mi noimbre es " + stringVarngVar);             // Imprimir variables con interpolacion de strings.
      Console.WriteLine($"Mi apellido es {apellido}");                        // Otra manera de interpolar.
      Console.WriteLine($"Mi apellido continene {apellido.Length} letras.");  // Length: Cantidad de caracteres.

      string[] stringArray = { stringVar, apellido, "Antonio" };              // Definicion de un array de string.
      Console.WriteLine($"Mi array contiene {stringArray.Length} elementos"); // Length: Cuenta la cantidad de variables dentro de un array.
    }

    static void StringMethods() {
      string test = "  Test String  ";
      Console.WriteLine(test.toUpper());  // Convierte a MAYUSCULA.
      Console.WriteLine(test.toLower());  // Convierte a minuscula.
      Console.WriteLine(test.Trim());     // Remueve espacios al principio y al final. TrimStart y TrimEnd son especificos.
      Console.WriteLine(test.Replace("Test", "TEST"));// Reemplaza TODAS LAS OCURRENCIAS del primer argumento con el segundo argumento pasado.

      if (test.Contains("Test")) Console.WriteLine("Se ha encontrado la palabra Test"); // True si encuentra la palabra.

      // stringVar.StartsWith(string);  // Busca al principio.
      // stringVar.EndsWith(string);    // Busca al final.

      // true -> True en la consola.
      // false -> False en la consola.
    }

    static void NumberMethods() {
      int x = 10, y = 20, z = 30;       // Integer.
      double xdouble = 10.5;            // double (mas memoria que un float).
      double a = 10;

      Console.WriteLine(x / y)          // 0 -> int / int produce un int.
      Console.WriteLine(a / y)          // 0.5 -> double / int produce un double.
      Console.WriteLine(x % y)          // 10 -> Devuelve el resto.

      Console.WriteLine(int.MaxValue);  // Devuelve el maximo valor posible de un entero (int).
      Console.WriteLine(int.MinValue);  // Devuelve el minimo valor posible de un entero (int).

      decimal d = (decimal) 1.0 / (decimal) 3.0;  // Casteo, si no los numeros decimales son implicitamente double.
      d = 1M / 3M;                      // xM indica que se debe interpretar el numero como un decimal.
      Console.WriteLine(d);             // El tipo decimal tiene un menor rango que un double pero tiene mas precision.
    }

    decimal calculateRadius(decimal radius) {       // Math.PI -> Representa el numero PI (Double).
      return (decimal) Math.PI * radius * radius;
    }

    static void ConditionalOperators() {
      bool test = false, secondTest = true, thirdTest = true;

      if (test) Console.WriteLine("True");
      else Console.WriteLine("False");

      if (test && secondTest) Console.WriteLine("First Test");
      else if ((test || thirdTest) && secondTest) Console.WriteLine("Second Test");
      else Console.WriteLine("Third Test");

      int flag = 0;

      while (true) {
          flag++;
          if (flag > 10) break;       // Do While funciona igual.
      }

      for(int i = 0; i < 10; i++) {
        Console.WriteLine(i);
      }

      int[] foreachTest = {1, 2, 3, 4, 5};

      foreach(int val in foreachTest) {   // Foreach recorre colecciones.
        Console.WriteLine(val);
      }
    }
    
    static void Lists() {
      var names = new List<string> { "Federico", "Romero", "Antonio" };     // Especificamos el tipo de elemento entre <>.

      names.Add("Otro nombre..."); // Inserto un elemento.
      names.Remove("Romero");      // Remueve un elemento y lo retorna, solo la primera ocurrencia. Si no lo encuentra, no hace nada y retorna false.
      //names.RemoveAt(0);         // Remueve por indice.
      names.RemoveAll(name => name.Length > 10) // Remueve todos los elementos que cumplan la condicion del delegado.
      names.AddRange(new string[] { "Uno", "Dos", "Tres" }); // Insertado multiple con arrays.

      foreach(var name in names) {
        Console.WriteLine(name);
      }

      Console.WriteLine(names[0]); // Se pueden utilizar indices.
      Console.WriteLine(names.IndexOf("Federico")); // Retorna el indice del primer elemento encontrado. -1 si no lo encuentra.

      names.Sort();   // Ordena, por defecto, de menor a mayor.

      var fibonacciNumbers = new List<int> {1, 1};

      for(int i = 0; i < 18; i++) {
        fibonacciNumbers.Add(fibonacciNumbers[fibonacciNumbers.Count - 1] + fibonacciNumbers[fibonacciNumbers.Count - 2]);
      }

      foreach(var item in fibonacciNumbers)
        Console.WriteLine(item);
      }
  }
}