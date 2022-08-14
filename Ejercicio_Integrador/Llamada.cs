using System;
using System.Text;

namespace LlamadaClass {
  public class Llamada {
    protected float _duracion;
    protected string _nroDestino;
    protected string _nroOrigen;
    
    public Llamada(string origen, string destino, float duracion) {
      this._nroOrigen = origen;
      this._nroDestino = destino;
      this._duracion = duracion;
    }
    
    public float Duracion {
      get {
        return this._duracion;
      }
    }
    
    public string NroDestino {
      get {
        return this._nroDestino;
      }
    }
    
    public string NroOrigen {
      get {
        return this._nroOrigen;
      }
    }
    
    public virtual void Mostrar() {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"Origen: {this._nroDestino}");
      sb.AppendLine($"Destino: {this._nroOrigen}");
      sb.AppendLine($"Duracion: {this._duracion}");
      return sb.ToString();
    }
    
    public static int OrdenarPorDuracion(Llamada uno, Llamada dos) {
      return uno.Duracion.CompareTo(dos.Duracion);
    }
  } 
}