// Arrays:
// Unidimensionales, multidimensionales o anidados (jagged).
// El valor por defecto de los tipos numericos es 0.
// Mientras que para los tipos referenciales es nulo.

// Los elementos de un array pueden ser de cualquier tipo.
// Son elementos de tipo referencia -> clase abstracta System.Array.
// Implementan la interfaz IEnumerable, por lo que son iterables con foreach.

// Son de tamaño fijo!!!

/*
[acceso] Tipo[] nombre_array = new Tipo[CANT_ELEMENTOS];
*/

// Metodos:
// CopyTo -> Copia todos los elementos de un array unidimensional
// actual al especificado, desde el indice especificado.
// GetLength -> Obtiene el numero de elementos para una dimension especificada.
// GetLowerBound / GetUpperBound -> Obtiene el limite especificado para una dimension
// especificada.
// GetValue / SetValue -> Obtiene o establece valores del array.
// Initialize -> Inicializa todos los elementos del mismo, llamando al constructor por
// defecto.

// Propiedades
// Length -> Cantidad total de elementos, en todas las dimensiones.
// Rank -> Obtiene el numero de dimensiones.

// Multidimensionales:
/*
[acceso] Tipo[,] nombre_array = new Tipo[FILAS, COLUMNAS];
*/

public int[,] myArray =  new Array[10, 10];

// Strings:
// ### Metodos Estaticos ###

// Compare: Compara entre dos cadenas y devuelve:
// 0 si ambos son iguales.
// positivo si la primera cadena es mayor a la segunda.
// negativo en caso contrario.

// Concat: una o mas cadenas.

// Copy: Copia una cadena dentro de otra.

// ### Metodos de Instancia ###
// CompareTo: idem a Compare().
// Contains: True si se encuetra la sub-cadena.
// CopyTo: Idem a Copy().
// EndsWith/StartsWith: True si coincide la parte especificada con la sub-cadena.
// IndexOf/LastIndexOf: Retorna el indice de la primer o ultica ocurrencia de la sub-cadena.
// Insert: Inserta una cadena en una posicion especificada.
// Remove: Borra todos los caracteres apartir del indice pasado.
// Replace: Reemplaza todas las ocurrencias de la subcadena por otra.
// Substring: Retorna una subcadena a partir de un indice con una longitud determinada.
// ToLower/ToUpper: Retorna una cadena convertida a minuscula/mayuscula.
// TrimEnd/TrimStart: Remueve en el comienzo/final los caracteres especificados (default ' ').
// Trim: Remueve los espacios en blanco dek principio y del final de la instancia.

// ### Propiedades ###
// Chars: Es el indexador, obtiene el caracter en la posicion indicada: -> miCadena = "Hola" -> miCadena[1] == 'o';
// Length: Retorna la cantidad de caracteres.
