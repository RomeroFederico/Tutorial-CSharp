// Encapsulamiento:
// Esta asociado con ocultar al resto del mundo el interior de una clase.
// Simplifica la reutilizacion
// Solo se podra acceder a los metodos y propiedades publicos.
// Garantiza el buen uso del objeto.

// Propiedades: GET y SET.

public class Example {
  private string _nombre;

  public string Nombre { // Puede ser o no el mismo nombre que un atributo asociado.
    public get { return _nombre; } // Las propiedades tambien pueden tener modificadores de visibilidad.
    set { ._nombre = value } // Si queremos que sea de solo lectura, no utilizamos set.
  }

  public string Nombre { // C# 7.0
    get => _name;
    set => _name = value;
  }

  public string Name => "John Doe"; // Idem, pero solo lectura.
  public string Name => this._nombre.toUpper(); // Otro ejemplo.

  public string Nombre {  // Propiedades auto implementadas.
    get; set;             // Cuando tanto el get como el set 
  }                       // solo deben retornar y asignar el valor.
                          // Pero no debe declararse el atributo!!!

  public int Id {         // Tambien pueden haber propiedadets auto implementadas de solo lectura.
    get;                  // Solo pude inicializarse en el constructor (Id = 1, por ejemplo).
  }                       // Las propiedades auto implementadas de solo escritura no son posibles.

  public int Edad { get; set; } = 27; // Se puede agregar un valor por defecto. 

  public required string Nombre { // C# 11.0
    get; set;
  }
}

var item = new Example { Nombre = "Ejemplo" }; // Inicializador de objeto con required.