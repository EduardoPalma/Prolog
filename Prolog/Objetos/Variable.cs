namespace Prolog.Objetos;

public class Variable : Termino
{
    private string nombre { get; set; }

    public Variable(string nombre)
    {
        this.nombre = nombre;
    }
    
    public string GetNombre()
    {
        return nombre;
    }
}