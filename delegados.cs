// Delegados:
// Son objetos al que otros objetos ceden o delegan la ejecucion de su codigo.
// Pueden invocar uno o varios metodos a la vez.
// Pueden encontrarse en la misma clase o en distintas.
// Son punteros a funciones, por asi decirlo.

// Metodos:
/*
Combine(): concatena la lista de invocaciones.
GetInvocationList(): devuelve la lista de invocaciones.
Invoke(): Invoca al metodo asociado.
Remove/All(): Remueve el ultimo metodo o toda la lista de invocacion.
/*

// Propiedades (solo lectura):
/*
Method: obtiene el metodo representadi por el delegado.
Target: obtiene la instancia de la clase donde el delegado actual invoca al metodo.
*/

// Se indica la firnma de los posibles metodos qye podra apuntar el delegado.
public delegate void ExampleDelegate(int value);
// Ya se puede crear una variable del tipo delegado que creamos.
public ExampleDelegate ExampleVariable = new ExampleDelegate(method);