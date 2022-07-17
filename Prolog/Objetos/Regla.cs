namespace Prolog.Objetos;

public class Regla : Clausula
{
    public Regla(string nombre)
    {
        Name = nombre;
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
            Console.Write(clausula.Name + " ");
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
                Console.Write("  "+v.Name + " ");
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
                Console.Write("  "+v.Name + " ");
            }
        }
    }
    
    
}