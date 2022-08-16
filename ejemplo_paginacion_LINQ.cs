using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

// Fuente: https://csharp.net-tutorials.com/linq/limiting-data-the-take-skip-methods/

namespace LinqTakeSkip1
{
  class Program
  {
    static void Main(string[] args)
    {
      CultureInfo usCulture = new CultureInfo("en-US");
      XDocument xDoc = XDocument.Load("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
      var cubeNodes = xDoc.Descendants().Where(n => n.Name.LocalName == "Cube" && n.Attribute("currency") != null).ToList();
      var currencyRateItems = cubeNodes.Select(node => new
      {
        Currency = node.Attribute("currency").Value,
        Rate = double.Parse(node.Attribute("rate").Value, usCulture)
      });


      int pageSize = 5, pageCounter = 0;
      var pageItems = currencyRateItems.Take(pageSize);
      while(pageItems.Count() > 0)
      {
        foreach (var item in pageItems)
          Console.WriteLine(item.Currency + ": " + item.Rate.ToString("N2", usCulture));
        Console.WriteLine("Press any key to get the next items...");
        Console.ReadKey();
        pageCounter++;
        // Here's where we use the Skip() and Take() methods!
        pageItems = currencyRateItems.Skip(pageSize * pageCounter).Take(pageSize);
      }
      Console.WriteLine("Done!");
    }
  }
}