using Prolog.LecturaArchivo;
using Prolog.Objetos;

namespace Prolog.Arbol;

public class Arbol
{
    public List<Clausula> Clausulas { get; set; }
    private Interprete i;
    public Arbol(Interprete i)
    {
        this.i = i;
        Clausulas = new List<Clausula>();
        GenerarArbol();
    }

    public List<Clausula> getClausulas()
    {
        return Clausulas;
    }
    

    private string Espacios(int i)
    {
        string espacios = "";
        if (i > 0)
        {
            for (int j = 0; j < i; j++)
            {
                espacios += "   ";
            }
            espacios += "+-";
        }
        return espacios;
    }

    public bool Imprimir(List<Clausula> list,int i)
    {
        if (list.Count > 0)
        {
            foreach (var terminos in list)
            {
                if (terminos is Hecho)
                {
                    Console.WriteLine(Espacios(i)+terminos.Name +" is H");
                    Hecho h = (Hecho)terminos;
                    h.MostrarTerminos(Espacios(i+1));
                }
                else
                {
                    Console.WriteLine(""+Espacios(i)+ terminos.Name+ " is R");
                    var r = (Regla)terminos;
                    //r.MostrarTerminosClausulas();
                    Imprimir(r.ListaClausulas,i+1);
                }
            }
            return true;
        }
        return false;
    }

    private void GenerarArbol()
    {
        foreach (var regla in i.ListaReglas)
        {
            for (int j = 0; j < regla.ListaClausulas.Count; j++)
            {
                Hecho h = BuscarHecho(regla.ListaClausulas[j].Name);
                if (h != null)
                {
                    regla.ListaClausulas[j] = h;
                }
                else
                {
                    int index = BuscarRegla(regla.ListaClausulas[j].Name);
                    regla.ListaClausulas[j] = Clausulas[index];
                    Clausulas.RemoveAt(index);
                }
            }
            Clausulas.Add(regla);
        }
    }

    private Hecho BuscarHecho(string nombreHecho)
    {
        foreach (var hecho in i.ListaHechos)
        {
            if (hecho.Name.Equals(nombreHecho))
            {
                return hecho;
            }
        }

        return null!;
    }

    private int BuscarRegla(string nombreRegla)
    {

        for (int i = 0; i < Clausulas.Count; i++)
        {
            if (Clausulas[i].Name.Equals(nombreRegla))
            {
                return i;
            }
        }
        return 0;
    }
}