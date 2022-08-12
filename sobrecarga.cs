// Sobrecarga de metodos:

// Un metodo no puede tener el mismo nombre que otro elemento en la misma clase.
// Pero si dos o mas metodos pueden compartir el nombre.

// Para sobrecargar el metodo, se debe cambiar la firma del mismo:
// El tipo y numero de parametros.
// Una firma debe ser unica dentro de la clase.
// La firma ademas contiene: nombre y modificador (out y ref).
// Ni el nombre de los argumentos ni el tipo de retorno influyen en la firma. 

public class Overload {
  static int Sumar(int a, int b) {
    return a + b;
  }

  static int Sumar(int a, int b, int c) {
    return a + b + c;
  }

  static int Sumar(double a, double b) {
    return a + b;
  }
}

// Sobrecarga de Constructores:
// Idem a los metodos.
// Da la posibilidad de poder instanciar objetos de distintas maneras.

public class Overload {
  private int _id;
  public string name;

  public Overload() {
    this._id = 0;
    this.name = "Nuevo";
  }

  public Overload(int id) {
    this._id = id;
    this.name = "Nuevo";
  }

  public Overload(int id, string name) {
    this._id = id;
    this.name = name;
  }
}

// Sobrecarga de Operadores:
// Modifica el comportamiento de uno o mas operadores cuando es utilizado con clases.

/* 
[acceso] static TipoRetorno operator nombreOperador(Tipo a[, Tipo b]) {
  ...
}
*/

// Son estaticos!!!

// Lista de operadores sobrecargables:

// + - ! ~ ++ -- true false ### UNARIOS
// + - * / % & | ^ << >>    ### BINARIOS
// == != < > <= >=          ### COMPARACION (En pares)
// Nota: No se puede sobrecargar pero...
// [] indexador de array, pero se pueden definir indexadores.
// () casting, pero se pueden definir nuevos operadores de conversion.
// de asignacion, pero se puede sobrecargar los operadores asociados (+ - etc).

public class Metro {
  public double cantidad;

  public Metro() {
    this.cantidad = 0;
  }

  public Metro(double cantidad) {
    this.cantidad = cantidad;
  }

  public static Metro operator + (Metro m, Centimetro c) {
    Metro retValue = new Metro();
    retValue.cantidad = m.cantidad + c.cantidad / 100;
    return retValue;
  }

}

public class Centimetro {
  public double cantidad;

  public Centimetro() {
    this.cantidad = 0;
  }

  public Centimetro(double cantidad) {
    this.cantidad = cantidad;
  } 

  public static Centimetro operator + (Centimetro c, Metro m) {
    Centimetro retValue = new Centimetro(c.cantidad + m.cantidad * 100);
    return retValue;
  } 
}

Metro metros = new Metro(10);
Centimetro centimetros = new Centimetro(10);

Metro sumaEnMetros = metros + centimetros;
Centimetro sumaEnCentimetros = centimetros + metros;

Console.WriteLine(sumaEnMetros.cantidad);       // 10.1
Console.WriteLine(sumaEnCentimetros.cantidad);  // 1010

// Operadores de conversion:
// Permite hacer compatibles tipos que antes no lo eran.
// Pueden ser explicitos o implicitos.

// Implicitos:
// public static implicit operator nombreTipo(Tipo A)
// Explicitos:
// public static explicit operator nombreTipo(Tipo A)

// Ejemplo explicit:

public class Metro {
  public double cantidad;

  public static explicit operator Metro(double cant) {
    Metro retValue = new Metro(cant);
    return retValue;
  }

  public static explicit operator Double(Metro m) {
    return m.cantidad;
  }
}

public class Centimetro {
  public double cantidad;

  public static explicit operator Centimetro(double cant) {
    Centimetro retValue = new Centimetro(cant);
    return retValue;
  }

  public static explicit operator Double(Centimetro c) {
    return m.cantidad;
  }
}

Metro metros = (Metro) 10;
Centimetro centimetros = (Centimetro) 10;

Metro sumaEnMetros = metros + centimetros;
Centimetro sumaEnCentimetros = centimetros + metros;

Console.WriteLine((double) sumaEnMetros);
Console.WriteLine((double) sumaEnCentimetros);

// Ejemplo implicit:

public class Metro {
  public double cantidad;

  public static implicit operator Metro(double cant) {
    Metro retValue = new Metro(cant);
    return retValue;
  }

  public static implicit operator Double(Metro m) {
    return m.cantidad;
  }
}

public class Centimetro {
  public double cantidad;

  public static implicit operator Centimetro(double cant) {
    Centimetro retValue = new Centimetro(cant);
    return retValue;
  }

  public static implicit operator Double(Centimetro c) {
    return m.cantidad;
  }
}

Metro metros = 10;
Centimetro centimetros = 10;

Metro sumaEnMetros = metros + centimetros;
Centimetro sumaEnCentimetros = centimetros + metros;

Console.WriteLine(sumaEnMetros.cantidad);
Console.WriteLine(sumaEnCentimetros.cantidad);