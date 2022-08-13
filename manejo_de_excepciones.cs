// Manejo de Excepciones:
// Permite interceptar con exito errores en tiempo de ejecucion.
// Cuando se produce un error se lanza una excepcion.

// El Objeto Exception:
// Todas las excepciones derivan de la clase Exception (CLR = Common Lenguage Runtime).
// Los mensajes de error no estan representados por valores enteros o enumerados.
// Se generan mensajes de error significativos.
// Cada clase de excepcion es descriptiva y representa un error concreto.
// Ademas, pueden poseer informacion especifica al error ocurrido.
// OutOfMemoryException, IOException, NullReferenceException, etc...

try {
  // Las partes del codigo que son propensas a lanzar un excepcion se colocan
  // dentro del bloque try.
  // En caso de producirse un error, el runtime detiene la ejecucion normal del
  // oodigo y empieza a buscar un bloque catch que pueda capturar la excepcion
  // basandose en su tipo.
  // Si no lo encuentra en su contexto de ejecucion, volvera "para atras" hasta
  // poder encontrar alguno. Si no tiene exito, el programa se cerrara.
  double inevitableError = 1 / 0;

  // Es posible lanzar un error de manera manual.
  // El tipo de excepcion puede ser cualquiera que sea valido, es decir,
  // Que deriven de la clase System.Exception.
  // Esto incluye las creadas por el usuario.
  throw new Exception("Example");
}
catch(IOException e) {
  // El codigo referido para el tratamiento del error se coloca en el bloque catch.
  // El tipo de dato de la exception debe ser System.Exception o una clase derivada.

  // Si el error es capturado, se ejecutara el codigo de este bloque y se continuara
  // la ejecucion del codigo de manera normal.

  // Tambien se pueden lanzar excepciones dentro del bloque catch.
  // Incluso el mismo objeto!
  throw e;

  // Se debe tener cuidado si se convierte en otro tipo de excepcion al lanzar una
  // nueva. Por norma general, se debe ajustar la informacion, añadiendo datos
  // relevantes al error.
}
catch(Exception e) {
  // Es posible encadenar multiples catch en un solo bloque try-catch.
  // Esto se debe a que la captura de un error dependera del tipo que tenga el bloque
  // catch. Por esto, cada bloque puede tener un catch con un tipo especifico.

  // Es recomendable que el ultimo catch de la cadena sea del tipo generico para poder
  // capturar cualquier error sin un controlador adecuado.

  // En un bloque try-catch no se puede repetir mas de una vez un tipo de error.
}
finally() {
  // Al finalizar la ejecucion del bloque, ya sea dentro del bloque try o en catch si
  // salto una excepcion, se pasara a este sector.
  // Tambien se ejecutara si se abandona este bloque con un throw, break o continue.
}