// POO
// Resuelve problemas de la realidad a traves de identificar objetos y
// relaciones de colaboracion entre ellos.

// Una clase incluye comportamientos comunes (metodos) y estados (atributos-propiedades).

// Pilares:
// Herencia: De la generalizacion a la especializacion. Relacion: "Es un".
// Polimorfismo: La definicion del metodo reside en la clase base.
// Pero su implementacion reside en la clase derivada o hija.
// Tambien se refiere a que de una clase padre se pueden crear multiples clases
// distintas con comportamientos distintos.
// Encapsulamiento: Responde a peticiones a traves de metodos y propiedades, 
// sin exponer los medios utilizados para llegar a brindar estos resultados.
// Abstraccion: Ignorancia selectiva. Decide que es importante y que no lo es.

// Sintaxis:
// [modificador] class Identificador {
//    atributos y metodos
// }

// Modificador -> Accesibilidad.
// class -> Le indica al compilador que se esta definiendo una clase.
// Identificador -> Nombre de la clase (Sustantivo, capitalizado).

// Modificadores
// abstract: No instanciable.
// sealed: No puede heredar
// Modificadores de Visiblidad
// internal: Accesible en todo el proyecto.
// public: Accesible desde cualquier proyecto.
// private: Por defecto, solo visible por la clase padre.

public class Auto {

  private string _patente; // Por defecto, Private y protected -> _propiedad.
  public string color;
  // Modifadores
  // private: Solo la misma clase.
  // protected: Idem y clases derivadas.
  // internal: Todo el proyecto.
  // internal protected: Idem o clases derivadas.
  // public: Cualquier miembro.

  public Auto(string patente, string color) {
    this._patente = patente;
    this.color = color;
  }

  // Metodos -> Con verbos.
  // [modificador] tipo_retorno Identificador([args]).
  // args: tipo_dato identificador, tipo_dato identificador.
  // 'void' si no retorna nada.

  // Modificadores:
  // abstract: Solo la firma.
  // static: Metodo de clase.
  // extern: Firma del metodo (para metodos externos).
  // virtual: Define e implementa metodos, que pueden ser sobreescritos.
  // override: Reemplaza la implementacion de uno VIRTUAL en una clase padre.
  // internal, public, protected, private: De visibilidad. 
  public string GenerateString() {
    return $"{this._patente}-{this.color}";
  }

  public void SetPatente(string newPatente) {
    this._patente = newPatente;
  }
}

Auto newCar = new Auto("ABC-123", "Blue"); // Instancia de una clase.
Console.WriteLine(newCar.GenerateString()); // Llamado al metodo.
newCar.SetPatente(newPatente: "DFE-456");
// Se puede indicar el nombre de los argumentos.
// En este caso, los argumentos pueden ponerse en cualquier orden.

// NameSpace
// Agrupacion logica de clases y otros elementos.
// Toda clase esta dentro de un NameSpace.
// Permite organizar el codigo de manera organizada y jerarquica.
// Reduce los conflictos entre nombres.
// Se situan en el nivel superior de la jerarquia de elementos de C#.
// Solo un NameSpace puede contener a otro. 

// System.Console.WriteLine()
// System es un NameSpace de la BCL
// Console es una clase.
// WriteLine es un metodo estatico de Console.

// Directivas:
// Permiten identificar los NameSpaces a utilizar en el programa.
// Permite utilizar sus miembros sin tener que especificar el nombre completo.
// Using y Alias

// using: Permite utilizar metodos y clases sin utilizar el nombre del NameSpace.
// alias: Permite que el programa utiliza otro nombre para el NameSpace especificado.
// Tambien se puede utilizar con metodos y clases dentro del NameSpace.

using SC = System.Console;

// Definicion:
namespace MyNameSpace { // Misma convencion que las clases.
  /* 
    Contiene:
    - Clases
    - Delegados
    - Enumeraciones
    - Interfaces
    - Estructuras
    - NameSpaces
    - Directivas using
    - Directivas Alias
  */
}