using System;
using CentralitaClass;
using LlamadaClass;
using LocalClass;
using ProvincialClass;

namespace MainClass {
  public class Program {
    
    public static void Main() {
      Centralita miCentral = new Centralita("Telefónica");

      Local primera = new Local("Merlo", 30F, "Glew", 2.65F);
      Provincial segunda = new Provincial("Avellaneda", Franja.Franja_1, 21, "Moron");
      Local tercera = new Local("Glew", 45, "Longchamps", 1.99F);
      Provincial cuarta = new Provincial("Moron", Franja.Franja_3, 21, "Avellaneda");

      miCentral += primera;
      miCentral += segunda;
      miCentral += tercera;
      miCentral += cuarta;

      Console.WriteLine(miCentral.ToString());
      miCentral.OrdenarLlamadas();
      Console.WriteLine(miCentral.ToString());
    }
  }
}