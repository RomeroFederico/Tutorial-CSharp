// Clases Abstractas:

// Ademas de poseer miembros de clases normales, pueden tener miembros abstractos.
// Estos son metodos y propiedades que solo se declaran, no se implementan.
// Pero sus clases derivadas TIENEN que implementarlos.
// No se pueden instanciar!!!

// Sirven para establecer la estructura del codigo, ya que poseen infomacion y un 
// comportamiento comun a todas las clases derivadas de un marco de trabajo.

// Solo las clases abstractas pueden tener miembros abstractos.
public abstract class Example {
  public abstract void ExampleMethod();
  // Solo se declara la firma y debe tener un punto y coma (;) al final.
}

public class ExampleChild : Example {

  // Se debe sobrescribir el metodo.
  // Un metodo abstract es, a su vez, virtual (implicitamente).
  public override void ExampleMethod() {
    Console.WriteLine("Method has been Overrided");
  }

  // Un metodo virtual indica que puede ser parcial o totalmente sobrescrito.
  // A diferencia de los metodos abstractos, pueden implementarse en la clase base.
  public virtual string ExampleVirtual(string value) {
    return value.ToUpper();
  }
}

public class ExampleGrandChild : ExampleChild {

  // Al ser implicitamente virtuales, un metodo abstracto puede ser sobrescrito
  // en las clases heredadas.
  // Un metodo virtual se sobrescribe con override.
  public override void ExampleMethod() {
    base.ExampleMethod(); // Se puede o no llamar al metodo original.
    Console.WriteLine("Method has been Overrided Again");
  }

  // Notese que un metodo virtual, a diferencia de los abstractos, no necesariamente
  // tiene que ser sobrescrito.
}

// Polimorfismo:

// Es cuando los objetos permiten invocar un metodo generico, cuya implementacion
// sera delegada al objeto correspondiente solo en tiempo de ejecucion.
// Es decir, dependiendo del objeto, un metodo puede o no variar su comportamiento.

// Interfaces:

// Contrato que establece una clase en el cual esta clase debera implementar un
// conjunto de metodos.
// Podria decirse que son clases abstractas, sin atributos, en donde todos sus
// metodos son abstractos.
// Todos sus metodos son publicos y abstractos!!!
// Es posible especificar propiedades.
// Una clase puede implementar multiples interfaces (herencia multiple simulada).

// Es posible modificar la visibilidad de una interfaz.
public interface IExampleInterface {
  void ExampleInteraceMethod(int value); 
}

public class ExampleGrandChildWithInterface : ExampleGrandChild, IExampleInterface {

  // No se utiliza override ya que el metodo nunca se declaro como virtual.
  public void ExampleInteraceMethod(int value) {
    return value * 2;
  }
}