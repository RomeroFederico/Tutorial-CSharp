using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Program {
  
  public static void Main() {
    var names = new List<string>() {  
        "John Doe",  
        "Jane Doe",  
        "Jenna Doe",  
        "Joe Doe"  
    };  

    // LINQ permite trabajar con datos de la misma manera, ya sea con listas, diccionarios, archivos XML, tablas de db, etc.
    // Metodo QUERY:
    var shortNames = from name in names where name.Length <= 8 orderby name.Length select name;

    foreach (var name in shortNames)  
      Console.WriteLine(name);

    // Con METODOS (utilizando LAMBDAS):
    var moreShortNames = names.Where(name => name.Length <= 8).Where(name => !name.StartsWith('Z')); // Se puede encadenar.
    moreShortNames = moreShortNames.OrderByDescending(name => name.Length); // Ascendente
    moreShortNames = moreShortNames.OrderBy(name => name).ThenBy(name.Length); // Descendente y luego ascendente si hay empate.
    // Igualmente, ThenByDescending() es descendente cuando hay empate.
  
    // Con query es de la siguiente manera:
    // List<User> sortedUsersQ = (from user in listOfUsers orderby user.Age ascending, user.Name descending select user).ToList();

    moreShortNames = moreShortNames.Skip(1).Take(2).ToList(); // Skip() salta x elemetos, Take() devuelve x elementos.

    names.Add("Zoe Doe");

    // Una caracteristica de LINQ es que se ejecutara solo cuando los datos sean necesarios, por asi decirlo.
    // Por lo que podemos seguir modificando el origen, por lo que LINQ trabajara con la version mas actualizada. 
    foreach (var name in moreShortNames)
      Console.WriteLine(name);
  }
}