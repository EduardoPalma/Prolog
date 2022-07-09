using Prolog.Objetos;

namespace Prolog.Arbol;

public class Arbol
{
    private List<Clausula> Clausulas { get; set; }

    public Arbol(List<Clausula> list)
    {
        Clausulas = list;
    }

    public List<Clausula> getClausulas()
    {
        return Clausulas;
    }

    public bool Imprimir(List<Clausula> list)
    {
        if (list.Count > 0)
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
                    Imprimir(r.ListaClausulas);
                }
            }

            return true;
        }

        return false;
    }
}