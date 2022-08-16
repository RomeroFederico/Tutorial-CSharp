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

    // Select() nos permite tomar los datos y transformarlos a nuestro gusto.
    List<User> users = new List<User>() {
      new User() { Name = "John Doe", Age = 42 },  
      new User() { Name = "Jane Doe", Age = 34 },  
      new User() { Name = "Joe Doe", Age = 8 },  
      new User() { Name = "Another Doe", Age = 15 },
    };

    // El valor retornado sera cada elemento que compondra nuestra lista final.
    List<string> names = users.Select(user => user.Name).ToList();
    var usersWithAnonymousType = names.Select(name => new { Name = name });
    // CON QUERY:
    var usersWithAnonymousTypeQ = (from name in names select new { Name = name }).ToList();

    foreach (var user in usersWithAnonymousType)
      Console.WriteLine(user.Name);

    // GroupBy() nos permite agrupar datos de acuerdo al valor retornado por el metodo lamda.
    // Esto creara una lista con objetos, donde cada uno tendra la propiedad Key con el valor previamente retornado,
    // y los demas objetos podran ser recorridos, ya que implementan la interfaz IEnumerable.
    var usersGroupedByAge = users.GroupBy(user => GetGroupAge(user));
    foreach (var userGroup in usersGroupedByAge) {
      Console.WriteLine($"userGroup: {userGroup.Key}");
      foreach (var user in userGroup)
        Console.WriteLine($"user: {user.Name}, age: {user.Age}");
    }

    // Es posible crear llaves compuestas.
    var usersGroupedByAgeAndFirstLetter= users.GroupBy(user => GetGroup(user));
    foreach (var userGroup in usersGroupedByAgeAndFirstLetter) {
      Console.WriteLine($"GroupAge: {userGroup.Key.GroupAge}, FirstLetter: {userGroup.Key.FirstLetter}");
      foreach (var user in userGroup)
        Console.WriteLine($"user: {user.Name}, age: {user.Age}");
    }
  }

  public static string GetGroupAge(User oneUser) {
    return oneUser.Age >= 18 ? "Adult" : "Minor";
  }

  public static dynamic GetGroup(User oneUser) {
    return new { GroupAge = GetGroupAge(oneUser), FirstLetter = oneUser.Name.ElementAt(0) };
  }

  public class User  
  {  
    public string Name { get; set; }  
    public int Age { get; set; }  
  }
}