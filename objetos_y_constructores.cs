// Objetos
// Instancias de una clase, creados en tiempo de ejecucion.
// Contienen atributos y metodos (comportamientos y estados).

public class Ejemplo {
  public Ejemplo() {

  }
}

Ejemplo instanciaEjemplo = new Ejemplo();
// new asigna memoria.
// El constructor inicializa un objeto en esa memoria.
// Solo cuando se destruye el objeto se libera la memoria. Automatico, no manual.

// Una variable tendra un ciclo de vida dependiendo del ambito donde se declare.
// En cambio un objeto no esta vinculado a su ambito.
// Se borra su referencia pero no su valor!!!

// Solo se borrara cuando el Garbage Collector detecte que es inalcanzable y falte memoria.

// Tipos de constructores:

// De instancia: Inicializan objetos.
// Estaticos: Inicializan clases.

public class EjemploInstancia {

  private int _id;
  public string name;

  // De instancia:
  // Por defecto.
  // Mismo nombre de la clase.
  // No retorna nada (no se coloca void).
  // public EjemploInstancia() {
  // Los campos no inicializados tendran su valor predeterminado:
  // 0, false o null.
  // }

  public EjemploInstancia(int id, string name) {
    this._id = id;
    this.name = name
  }
}

public class EjemploStatico {

  // Estaticos:
  // Inicializan clases.
  // Solo pueden inicializar atributos estaticos.
  // No lleva modificadores de acceso.
  // Utiliza static.
  // No recibe parametros.
  private static int _var;
  private static string _name;

  static EjemploStatico() {
    _var = 123;   // No utiliza this.
    _name = "Ejemplo";
  }
}

new EjemploStatico();