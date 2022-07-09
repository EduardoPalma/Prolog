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
}