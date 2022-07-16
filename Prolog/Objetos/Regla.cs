namespace Prolog.Objetos;

public class Regla : Clausula
{
    internal List<Clausula> ListaClausulas { get; set; }
    private List<List<Termino>> ListaTerminoCLausulas { get; set; }
    private List<List<Termino>> ListTerminos { get; set; }

    public Regla(string nombre)
    {
        _name = nombre;
        ListaClausulas = new List<Clausula>();
        ListTerminos = new List<List<Termino>>();
        ListaTerminoCLausulas = new List<List<Termino>>();
    }

    public void InsertarClausula(Clausula c)
    {
        ListaClausulas.Add(c);
    }

    public void InsertarVariables(List<Termino> variables)
    {
        ListTerminos.Add(variables);
    }
    
    public void InsertarTerminoClausulas(List<Termino> variables)
    {
        ListaTerminoCLausulas.Add(variables);
    }

    public void MostrarClausulas()
    {
        foreach (var clausula in ListaClausulas)
        {
            Console.Write(clausula._name + " ");
            Hecho h = (Hecho)clausula;
            h.MostrarTerminos("");
        }
        Console.WriteLine();
    }

    public void MostrarTerminos()
    {
        foreach (var terminos in ListTerminos)
        {
            foreach (var t in terminos)
            {
                Variable v = (Variable)t;
                Console.Write("  "+v.GetNombre() + " ");
            }
        }
    }
    
    public void MostrarTerminosClausulas()
    {
        foreach (var terminos in ListaTerminoCLausulas)
        {
            foreach (var t in terminos)
            {
                Variable v = (Variable)t;
                Console.Write("  "+v.GetNombre() + " ");
            }
        }
    }
    
    
}