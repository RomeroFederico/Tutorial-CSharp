// Serializacion:
// Convierte objetos en memoria en una secuencia lineal de bytes.

// Formatters:
// Controla el formate de la serializacion.
// XML - Solo incluye propiedades publicas (por defecto).
// Binaria - Incluye todos los miembros (por defecto).
// Custom - Personalizado.

// ARCHIVOS TXT
// StreamWriter escribe caracteres en archivos de texto.
// StreamReader lee desde un archivo de texto.
// Pertenecen a System.IO.

// Inicializa una nueva instancia.
// Si el archivo existe, se sobrescribira, sino lo crea.
StreamWriter sw = new StreamWriter("./path.txt");
// El segundo argumento es append.
// Si es true, agregara datos, no sobreescribira.
StreamWriter sw = new StreamWriter("./path.txt", true);
// Para escribir en el archivo, se empleara el metodo write.
sw.Write("string value");
// Para cerrar el archivo, utilizamos close.
sw.Close();

// Inicializa una nueva instancia.
StreamReader sr = new StreamReader("./path.txt");
// Lee un caracter, avanzando caracter por caracter. Retorna un entero.
int CharacterReaded = sr.Read();
// Lee una linea de caracteres, avanzando linea por linea. Retorna un string.
string lineReaded = sr.ReadLine();
// Lee todo el stream. Retorna un string.
string fileReaded = sr.ReadToEnd();
// Para cerrar el archivo, utilizamos close.
sr.Close();

// Excepciones:
/*
ArgumentException: path de longitud 0, solo espacios o contiene caracteres invalidos.
ArgumentNullExceptin: ruta de acceso nulo.
FileNotFoundException: ruta no existente.
IOException: Archivo en uso o error de E/S.
PathTooLongException: ruta supera el limite maximo del sistema.
NotSupportedException: archivo o directorio contiene (:) o un formato invalido.
SecurityExceptin: Usuario no tiene los permisos necesarios para ver/modificar la ruta.
*/

// ARCHIVOS XML:
// Solo serializa campos publicos y valores de propedad de un objeto.
// No lo hara con metodos, indexadores, campos privados ni propiedades de solo lectura,
// salvo colecciones de solo lectura.
// BinaryFormatter permite serializar campos y propiedades privadas.

// XmlSerializer crea archivos .cs y los compila en archivos .dll en el directorio
// especificado por la variable de entorno TMP; la serializacion se produce con estos archivos.
// La clase a serializar debe tener un constructor por defecto.

// El argumento debe ser del tipo especificado a serializar (System.Type type) 
XmlSerializer xmlS = new XmlSerializer(typeof ClassToSerialize);
// XmlTextWriter provee una manera de generar archivos XML validos.
// El argumento debe ser el path del archivo xml y el tipo de codificacion. 
XmlTextWriter writer = new XmlTextWriter("./path.xml", "codificacion");
// Serializa el objeto, escribiendo en el documento xml asociado al writer.
xmls.Serialize(writer, objectToSerialize);
// Cierro el writer/archivo.
writer.Close();

// XmlTextReader provee una manera de leer archivos XML validos.
// El argumento debe ser el path del archivo xml.
XmlTextReader reader = new XmlTextReader("./path.xml");
// Deserializa el archivo xml asociado al reader en el objeto. Se debe castear.
ClassToSerialize xmlReaded = (ClassToSerialize) xmls.Deserialize(reader);
// Cierro el reader/archivo.
reader.Close();

// ARCHIVOS BINARIOS:
// Serializa y Deserializa objetos de manera binaria.
// Se encuentran en System.Runtime.Serialization.Formatters.Binary.
// Funciona con campos publicos y privados.
// La clase a serializar debe tener un constructor por defecto.

// Instancia del serializador.
BinaryFormatter binarySerializer = new BinaryFormatter();
// FileStream provee un objeto que puede leer, abrir y cerrar archivos.
// El argumento debe ser el path del archivo y el modo en que se creara o abrira. 
FileStream fs = new FileStream("./path", FileMode.Create);

// Metodos:
// Read(byte[] array, int offset, int count): Lee un bloque y escribe en el buffer.
// Seek(long offset, System.IO.SeekOrigin origin): Establece la posicion del stream.
// Write(byte[] array, int offset, int count): Escribe un bloque en el stream.

// Serializa el objeto, escribiendo en el documento asociado al fs.
binarySerializer.Serialize(fs, objectToSerialize);
// Cierro el fs.
fs.Close();

// Idem, pero con mode open.
FileStream fs = new FileStream("./path", FileMode.Open);
// Deserializa el archivo asociado al fs en el objeto. Se debe castear.
ClassToSerialize data = (ClassToSerialize) binarySerializer.Deserialize(fs);
// Cierro el fs.
fs.Close();