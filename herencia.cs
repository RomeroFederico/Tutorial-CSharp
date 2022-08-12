// Herencia:
// Relacion entre clases, en la cual una clase comparte la estructura y 
// comportamiento definido en otra clase.
// La clase hija poseera:
// - Los atributos de la clase base, mas los propios.
// - Soporta todos o algunos de los metodos de la clase base.
// Una subclase hereda de una clase base.
// Solo se puede heredar de solo una clase base (herencia simple).

public class BaseClass {
  protected int _id;

  public BaseClass(int id) {
    this._id = id;
  }
}

// Se hereda todo de la clase base, con excepcion de los constructores.
// Los miembros publicos se convierten implicitamente en publicos en la clase derivada.
// Aunque los heredan, solo la clase base puede acceder a sus miembros privados.
// Una clase derivada no puede ser mas accesible que su clase base.

public class DerivatedClass : BaseClass {

  public string name;

  // Si no se declara un constructor con :base([,args]), el compilador
  // usara implicitamente base().
  // Si una clase no contiene ningun constructor, el compilador utilizara
  // el por defecto.
  // No lo hara si la clase ya definio uno propio explicito.
  // Se generara un error si el constructor indicado no coincide con ningun
  // constructor de la clase base.
  public DerivatedClass(int id, string name): base(id) {
    this.name = name;
  }

  public int getId() {
    return this._id;
  }
}

// Para indicarle al compilador y a otros usuarios que una clase no puede heredar,
// Se utiliza la palabra reservada sealed.

public sealed class NoHierarchy {
  
}