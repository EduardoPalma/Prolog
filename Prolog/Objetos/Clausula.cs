namespace Prolog.Objetos;

public class Clausula
{
    public string Name { get; set; } = null!;
    public List<Clausula> ListaClausulas { get; set; } = new();
    public List<List<Termino>> ListTerminos { get; set; } = null!;
    public List<List<Termino>> ListaTerminoCLausulas { get; set; } = null!;
}