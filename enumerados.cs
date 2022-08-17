// ### Enumerados ###

public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

// Cada valor correspondera con un valor entero si no lo seteamos.
Console.WriteLine((int) Days.Tuesday); // 1.

public enum Days { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

// Si seteamos con un valor entero, cada valor siguiente tendra el valor asignado normalmente + el valor asingado;
// Puede haber valores repetidos. Por ejemplo, asignando con 0 cualquier elemento del enumerado que no sea el primero.
Console.WriteLine((int) Days.Tuesday); // 2.

// Tambien es posible obtener el valor del enumeraoo a traves de este indice.
Console.WriteLine((Days) 1); // Monday. 

// Se puede obtener el enumerado completo en formato string.
string[] values = Enum.GetNames(typeof(Days));
  foreach(string s in values)
    Console.WriteLine(s);

// NOTA: No es posible acceder al valor del enumerado a traves del indice como si se tratara de un array.
Console.WriteLine(Days[0]); // Error, Days es un tipo.

// ### Estructuras ###
// Alternativa liviana a las clases.
// Las instancias de las clsaes se alojan en la pila, mienstras que las estructuras se depositan en la cola.
// Trabajan con el dato en si, no con referencias, al contrario que las instancias de las clases.

// Una estructra no puede heredar de otra clase o estructura. Igualmente, una estructura no puede ser padre.
// Por otro lado, una estructura puede implementar interfaces.
struct Car {
  private string color;         // Los valores no pueden tener valor asignado por defecto.

  public Car(string color) {    // No puede definirse un constructo por defecto (ya viene con uno).
    this.color = color;         // Una vez declarado un constructor, deben inicializarse todos los campos de la estructura.
  }

  public string Describe() {
    return "This car is " + Color;
  }

  public string Color {
    get { return color; }
    set { color = value; }
  }
}

class Program {
  static void Main(string[] args) {
    Car car;

    car = new Car("Blue");
    Console.WriteLine(car.Describe());

    car = new Car("Red");
    Console.WriteLine(car.Describe());

    Console.ReadKey();
  }
}