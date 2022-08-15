using System;
using System.Text;
using Interfaces;
using System.IO;
using System.Runtime.Serialization;

namespace LlamadaClass {

  [Serializable()]
  public abstract class Llamada {
    protected float _duracion;
    protected string _nroDestino;
    protected string _nroOrigen;

    public Llamada() {

    }
    
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

    public abstract float CostoLlamada {
      get;
    }
    
    protected virtual string Mostrar() {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"Origen: {this._nroDestino}");
      sb.AppendLine($"Destino: {this._nroOrigen}");
      sb.AppendLine($"Duracion: {this._duracion}");
      return sb.ToString();
    }
    
    public static int OrdenarPorDuracion(Llamada uno, Llamada dos) {
      return uno.Duracion.CompareTo(dos.Duracion);
    }

    public static bool operator == (Llamada uno, Llamada dos) {
      return uno.Equals(dos) && uno._nroDestino == dos._nroDestino && uno._nroOrigen == dos._nroOrigen && uno._duracion == dos._duracion;
    }

    public static bool operator != (Llamada uno, Llamada dos) {
      return !(uno == dos);
    }
    
    public override bool Equals(object obj) {
      return obj is Llamada;
    }
      
    public override int GetHashCode() {
      unchecked
      {
        return this._duracion.GetHashCode() ^ this._nroDestino.GetHashCode() ^ this._nroOrigen.GetHashCode() ;
      }
    }
  }
}