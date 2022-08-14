using System;
using System.Text;
using LlamadaClass;

namespace LocalClass {
  public class Local : Llamada {
    
    protected float _costo;
    
    public Local(string origen, float duracion, string destino, float costo)
      :base(origen, destino, duracion) {
      this._costo = costo;
    }
    
    public Local(lLamada unaLlamada, float costo)
      :this(origen: unaLlamada.NroOrigen, destino: unaLlamada.NroDestino, duracion: unaLlamada.Duracion, costo: costo) {
    }
    
    public float CostoLlamada {
      get { return this.CalcularCosto();}
    }
    
    public override void Mostrar() {
      StringBuilder sb = new StringBuilder();
      sb.Append(base.Mostrar());
      sb.AppendLine($"Costo: {this.CalcularCosto()}");
      return sb.ToString();
    }
    
    private float CalcularCosto() {
      return this._costo * this._duracion;
    }
  }
}