namespace Prolog.Objetos;

public class Regla : Clausula
{
    internal List<Clausula> ListaClausulas { get; set; }

    public Regla(string nombre)
    {
        _name = nombre;
        ListaClausulas = new List<Clausula>();
    }

    public void InsertarClausula(Clausula c)
    {
        ListaClausulas.Add(c);
    }
    

    public void MostrarClausulas()
    {
        foreach (var clausula in ListaClausulas)
        {
            if (clausula is Hecho)
            {
                
            }
            else
            {
                
            }
        }
    }
    
    public bool Imprimir(List<Clausula> list)
    {
        if (list.Count == 0)
        {
            return true;
        }
        else
        {
            foreach (var terminos in list)
            {
                if (terminos is Hecho)
                {
                    Console.WriteLine(terminos._name);
                }
                else
                {
                    Console.WriteLine(terminos._name);
                    var r = (Regla)terminos;
                    return Imprimir(r.ListaClausulas);
                }
            }

            return false;
        }
    }
}