using System.Globalization; // CultureInfo forma parte de este namespace.

// ...

// CultureInfo:
// Importante a la hora de trabajar con usuarios de distintas culturas, al manejar numeros y fechas especialmente.
// CultureInfo posee informacion con respecto a este tema.

Console.WriteLine("Current culture: " + CultureInfo.CurrentCulture.Name);
// Retorna el nombre de la cultrua actual: xx-YY siendo xx las siglas del lenguaje, mientras que YY es la region.

float largeNumber = 12345.67f;
Console.WriteLine("Number format (Current culture): " + largeNumber.ToString());
CultureInfo.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine("Number format (Current culture): " + largeNumber.ToString());  // 12345.67
// Es posible cambiar el valor por defecto de la misma. 
CultureInfo myCulture = new CultureInfo("es-AR");
Console.WriteLine("Number format (Current culture): " + largeNumber.ToString(myCulture)); // 12345,67
// Tambien es posible utilizar una cultura particular en distintas operaciones.

// CurrentUICulture sirve al momento de trabajar con interfaces.

// Al momento de utilizar CurrentCulture solo se aplica al hilo (thread) actual.
// Cada hilo nuevo tendra el valor por defecto.
// Para solucionar esto, DefaultThreadCurrentCulture cambiara el valor a todos los hilos nuevos, como asi tambien
// al hilo actual si no se ha modificado antes.
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");

// Mas de una cultura comparten el mismo lenguaje => misma cultura.
// Si se quiere trabajar de forma generica, podemos trabajar con el padre 'parent' de una cultura.
Console.WriteLine(myCulture.DisplayName);         // Spanish (Argentina)
Console.WriteLine(myCulture.Parent.DisplayName);  // Spanish

// ...como asi tambien creandola.
CultureInfo es = new CultureInfo("es");
// Por ultimo, es posible crear una cultura a traves de su codigo LCID.
CultureInfo enUs = new CultureInfo(1033);

// Podemos acceder al listado completo de culturas especificas disponibles.
CultureInfo[] specificCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
foreach (CultureInfo ci in specificCultures)
  Console.WriteLine(ci.DisplayName);
Console.WriteLine("Total: " + specificCultures.Length);

// Si queremos filtrar por culturas/lenguajes neutrales.
CultureInfo[] neutralCultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
foreach (CultureInfo ci in neutralCultures)
  Console.WriteLine(ci.DisplayName);
Console.WriteLine("Total: " + neutralCultures.Length);

// Propiedades:
// DateTimeFormat: Informacion acerca a como se debe formatear la fecha y hora en la cultura especifica.
CultureInfo culture = new CultureInfo("en-US");
// Para obtener el primer dia de la semana.
Console.WriteLine("First day of the: " + culture.DateTimeFormat.FirstDayOfWeek.ToString());
// Para obtener como se decide la primera semana de año en el calendario (primer dia o la semana completa).
Console.WriteLine("First calendar week starts with: " + culture.DateTimeFormat.CalendarWeekRule.ToString());
// Para obtener como llaman a cada mes.
foreach (string monthName in culture.DateTimeFormat.MonthNames)
  Console.WriteLine(monthName);
// O un mes particular.
Console.WriteLine("Current month: " + culture.DateTimeFormat.GetMonthName(DateTime.Now.Month));
// Idem para obtener como llaman a cada dia.
foreach (string dayName in culture.DateTimeFormat.DayNames)
  Console.WriteLine(dayName);
Console.WriteLine("Today is: " + culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek));

// NumberFormat: Informacion acerca a como se formate los numeros en la cultura especifica.
// NOTA: Esto solo importa con los numeros cuando son mostrados, internamente, como valor, son iguales.
Console.WriteLine("NumberGroupSeparator: " + culture.NumberFormat.NumberGroupSeparator);  // Separador de miles.
Console.WriteLine("NumberDecimalSeparator: " + culture.NumberFormat.NumberDecimalSeparator); // Separador de decimales.
Console.WriteLine("NumberDecimalSeparator: " + culture.NumberFormat.CurrencySymbol); // Como muestra la moneda.

// Identificadores y nombres:
Console.WriteLine("Name: " + culture.Name); // languagecode-country/region-code, solo el primero si no se utiliza una region.
Console.WriteLine("TwoLetterISOLanguageName: " + culture.TwoLetterISOLanguageName); // Solo languagecode.
Console.WriteLine("ThreeLetterISOLanguageName: " + culture.ThreeLetterISOLanguageName); // Idem, pero en el formato de 3 letras.
Console.WriteLine("EnglishName: " + culture.EnglishName); // Nombre en ingles del lenguaje y region (si la hay).
Console.WriteLine("NativeName: " + culture.NativeName); // Nombre del lenguaje (NATIVO).


// RegionInfo:
// Asi como CultureInfo poseia informacion acerca del lenguaje/cultura, RegionInfo hara lo mismo con la region/pais.

RegionInfo region = new RegionInfo("es-AR"); // Podemos pasarle el codigo ISO 3166 o el codigo de la cultura. 
Console.WriteLine(region.EnglishName);

// O nuestra propia cultura por defecto/ que hallamos seteado.
RegionInfo regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
Console.WriteLine(regionInfo.EnglishName);

Console.WriteLine(regionInfo.CurrencySymbol);     // Simbolo de la moneda.
Console.WriteLine(regionInfo.ISOCurrencySymbol);  // Simbolo ISO de la moneda.
Console.WriteLine(regionInfo.CurrencyEnglishName);// Nombre de la moneda en ingles.
Console.WriteLine(regionInfo.CurrencyNativeName); // Nombre de la moneda (NATIVO).

Console.WriteLine(regionInfo.IsMetric ? "Metric" : "No Metric"); // Si utiliza el sistema metrico.

// Identificadores y nombres:
Console.WriteLine("Name: " + regionInfo.Name); // Codigo ISO 3166 de la region.
Console.WriteLine("DisplayName : " + regionInfo.DisplayName ); // Nombre completo de la region.
Console.WriteLine("EnglishName : " + regionInfo.EnglishName ); // Nombre en ingles de la region.
Console.WriteLine("NativeName : " + regionInfo.NativeName ); // Nombre de la region (NATIVO).
Console.WriteLine("TwoLetterISORegionName : " + regionInfo.TwoLetterISORegionName );
// Codigo ISO 3166 de la region, solo las dos letras correspondientes.
Console.WriteLine("ThreeLetterISORegionName  : " + regionInfo.ThreeLetterISORegionName  );
// Idem, pero con el codigo de 3 letras.