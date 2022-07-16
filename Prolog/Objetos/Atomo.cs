namespace Prolog.Objetos;

public class Atomo : Termino
{
    private string NombreAtomo { get; set; }

    public Atomo(string nombreAtomo)
    {
        NombreAtomo = nombreAtomo;
    }
    
    public string GetNombre()
    {
        return NombreAtomo;
    }
}