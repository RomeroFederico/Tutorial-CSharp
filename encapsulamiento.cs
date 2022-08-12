// Encapsulamiento:
// Esta asociado con ocultar al resto del mundo el interior de una clase.
// Simplifica la reutilizacion
// Solo se podra acceder a los metodos y propiedades publicos.
// Garantiza el buen uso del objeto.

// Propiedades: GET y SET.

public class Example {
  private string _nombre;

  public string Nombre { // Puede ser o no el mismo nombre que un atributo asociado.
    get { return _nombre; }
    set { ._nombre = value } // Si queremos que sea de solo lectura, no utilizamos set.
  }

  public string Nombre { // C# 7.0
    get => _name;
    set => _name = value;
  }

  public string Nombre {  // Propiedades auto implementadas.
    get; set;             // Cuando tanto el get como el set 
  }                       // solo deben retornar y asignar el valor.

  public required string Nombre { // C# 11.0
    get; set;
  }
}

var item = new Example { Nombre = "Ejemplo" }; // Inicializador de objeto con required.