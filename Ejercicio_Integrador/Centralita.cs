using System;
using System.Text;
using System.Linq;
using System.Collections.List;
using LlamadaClass;
using LocalClass;
using ProvincialClass;
using Enumerados;
using Interfaces;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace CentralitaClass {
  public class Centralita : ISerializable {
    private List<Llamada> _listaDeLlamadas;
    protected string _razonSocial;
    private string _ruta;
    
    public Centralita() {
      this._listaDeLlamadas = new List<Llamada>();
    }
    
    public Centralita(string razon):this() {
      this._razonSocial = razon;
    }

    public List<Llamada> Llamadas {
      get { return this._listaDeLlamadas; }
      set { this._listaDeLlamadas = value; }
    }

    public string RazonSocial {
      get { return this._razonSocial; }
      set { this._razonSocial = value; }
    }

    public string RutaDelArchivo {
      get { return this._ruta; }
      set { this._ruta = value; }
    }
    
    public float GananciaPorTotal {
      get { return this.CalcularGanancia(TipoLlamado.Todas); }
    }
    
    public float GananciaPorLocal {
      get { return this.CalcularGanancia(TipoLlamado.Local); }
    }
    
    public float GananciaPorProvincial {
      get { return this.CalcularGanancia(TipoLlamado.Provincial); }
    }
    
    private float CalcularGanancia(TipoLlamado tipo) {
      float total = 0;
      
      foreach(Llamada llamada in this._listaDeLlamadas) {
        if (tipo == TipoLlamado.Todas ||
            tipo == TipoLlamado.Local && llamada is Local ||
            tipo == TipoLlamado.Provincial && llamada is Provincial)
          total += (llamada is Local) ? ((Local) llamada).CostoLlamada : ((Provincial) llamada).CostoLlamada;
      }
      
      return total;
    }

    public void OrdenarLlamadas() {
      this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
    }
    
    public override string ToString() {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"Razon Social: {this._razonSocial}");
      sb.AppendLine($"Ganancia Total: {this.GananciaPorTotal}");
      sb.AppendLine($"Ganancia Llamadas Locales: {this.GananciaPorLocal}");
      sb.AppendLine($"Ganancia Llamadas Provinciales: {this.GananciaPorProvincial}");
      
      sb.AppendLine("Mostrando Detalles de las Llamadas:");
      sb.AppendLine();

      foreach(Llamada llamada in this._listaDeLlamadas) {
        sb.AppendLine(llamada.ToString());
      }
      
      return sb.ToString();
    }

    private void AgregarLlamada(Llamada nuevaLlamada) {
      this.Llamadas.Add(nuevaLlamada);
      try {
        if (this.GuardarEnArchivo(nuevaLlamada, true)) Console.WriteLine("\n>>> La llamada se ha registrado.\n");
      }
      catch (CentralitaException e) {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Clase que lo provoco  : " + ex.NombreClase);
        Console.WriteLine("Metodo que lo provoco : " + ex.NombreMetodo);
        Console.WriteLine("Excepcion interna     : " + ex.ExcepcionInterna.Message + "\n");
        Console.ReadKey();
      }
    }

    public static bool operator ==(Centralita central, Llamada nuevaLlamada) {
      foreach(Llamada llamada in central._listaDeLlamadas) {
        if (llamada == nuevaLlamada) return true;
      }
      return false;
    }

    public static bool operator !=(Centralita central, Llamada nuevaLlamada) {
      return !(central == nuevaLlamada);
    }

    public static Centralita operator +(Centralita central, Llamada nuevaLlamada) {
      if (central != nuevaLlamada) central.AgregarLlamada(nuevaLlamada);
      return central;
    }

    public bool Serializarse() {
      try {
        using (XmlTextWriter writer = new XmlTextWriter(this._ruta, Encoding.UTF8)) {
          XmlSerializer xmlS = new XmlSerializer(typeof Centralita);
          xmlS.Serialize(writer, this);
        }
      }
      catch(Exception e) {
        throw new CentralitaException("Error en Serializar la Centralita. ", "Centralita", "Serializarse()", ex);
      }
      return true;
    }

    public bool DeSerializarse() {
      try {
        using (XmlTextReader reader = new XmlTextReader(this._ruta)) {
          XmlSerializer xmlS = new XmlSerializer(typeof Centralita);
          Centralita newCentralitaData = (Centralita) xmlS.Deserialize(reader);
          this._listaDeLlamadas = newCentralitaData._listaDeLlamadas
          this._razonSocial = newCentralitaData._razonSocial;
        }
      }
      catch(Exception e) {
        throw new CentralitaException("Error en Deserializar la Centralita del archivo XML. ", "Centralita", "DeSerializarse()", ex);
      }
      return true;
    }

    public bool GuardarEnArchivo(Llamada unaLlamada, bool agrego) {
      try {
        using (StreamWriter writer = new StreamWriter(this._ruta, agrego)) {
          writer.WriteLine("/// Datos de la llamada ///");
          writer.WriteLine("Fecha : " + DateTime.Now);
          writer.WriteLine(unaLlamada.ToString());
        }
      }
      catch (Exception ex) {
        throw new CentralitaException("No se pudo escribir el archivo con la llamada. ", (unaLlamada is Local ? "Local" : "Provincial"), "AgregarLlamada()", ex);
      }
      return true;
    }
  }
}