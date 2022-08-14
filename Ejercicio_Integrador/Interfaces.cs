namespace Interfaces {

  public interface ISerializable {
    string RutaDelArchivo {
      get; set;
    }

    bool Deserializarse();

    bool Serializarse();
  }
}