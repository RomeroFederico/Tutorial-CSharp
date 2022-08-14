using System;
using System.Text;
using LlamadaClass;

namespace LocalClass {
  public class Local : Llamada {
    
    protected float _costo;

    public Local() {

    }
    
    public Local(string origen, float duracion, string destino, float costo)
      :base(origen, destino, duracion) {
      this._costo = costo;
    }
    
    public Local(Llamada unaLlamada, float costo)
      :this(origen: unaLlamada.NroOrigen, destino: unaLlamada.NroDestino, duracion: unaLlamada.Duracion, costo: costo) {
    }
    
    public override float CostoLlamada {
      get { return this.CalcularCosto();}
    }
    
    protected override string Mostrar() {
      StringBuilder sb = new StringBuilder();
      sb.Append(base.Mostrar());
      sb.AppendLine($"Costo: {this.CalcularCosto()}");
      return sb.ToString();
    }
    
    private float CalcularCosto() {
      return this._costo * this._duracion;
    }

    public override bool Equals(object obj) {
      return obj is Local;
    }

    public override string ToString() {
      return this.Mostrar();
    }
    
    public override int GetHashCode() {
      unchecked
      {
        return this._duracion.GetHashCode() ^ this._nroDestino.GetHashCode() ^ this._nroOrigen.GetHashCode() ^ this._costo.GetHashCode();
      }
    }
  }
}