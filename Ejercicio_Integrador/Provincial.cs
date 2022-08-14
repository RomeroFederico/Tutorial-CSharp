using System;
using System.Text;
using LlamadaClass;
using Enumerados;

namespace ProvincialClass {
  public class Provincial : Llamada {
    
    protected Franja _franjaHoraria;

    public Provincial() {

    }
    
    public Provincial(string origen, Franja franja, float duracion, string destino)
      :base(origen, destino, duracion) {
      this._franjaHoraria = franja;
    }
    
    public Provincial(Franja franja, Llamada unaLlamada)
      :this(origen: unaLlamada.NroOrigen, destino: unaLlamada.NroDestino, duracion: unaLlamada.Duracion, franja: franja) {
    }

    public override float CostoLlamada {
      get { return this.CalcularCosto();}
    }
    
    protected override string Mostrar() {
      StringBuilder sb = new StringBuilder();
      sb.Append(base.Mostrar());
      sb.AppendLine($"Franja Horaria: {this._franjaHoraria.ToString()}");
      sb.AppendLine($"Costo: {this.CalcularCosto()}");
      return sb.ToString();
    }
    
    private float CalcularCosto() {
      switch(this._franjaHoraria) {
        case Franja.Franja_1:
          return this._duracion * 0.99F;
        case Franja.Franja_2:
          return this._duracion * 1.25F;
        default:
          return this._duracion * 0.66F;
      }
    }

    public override bool Equals(object obj) {
      return obj is Provincial;
    }

    public override string ToString() {
      return this.Mostrar();
    }
    
    public override int GetHashCode()
    {
      unchecked
      {
        return this._duracion.GetHashCode() ^ this._nroDestino.GetHashCode() ^ this._nroOrigen.GetHashCode() ^ this._franjaHoraria.GetHashCode();
      }
    }
  }
}