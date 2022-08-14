using System;
using System.Text;
using System.Collections.List;
using LlamadaClass;
using LocalClass;
using ProvincialClass;
using Enumerados;
using Interfaces;

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
      this._listaDeLlamadas.Add(nuevaLlamada);
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
  }
}