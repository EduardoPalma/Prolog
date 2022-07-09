namespace Prolog.Objetos;

public class Hecho : Clausula
{
    private List<List<Atomo>> ListTerminos { get; set; }

    public Hecho(string nombre)
    {
        _name = nombre;
        ListTerminos = new List<List<Atomo>>();
    }

    public void InsertarTerminos(List<Atomo> listaAtomos)
    {
        ListTerminos.Add(listaAtomos);
    }

    public void MostrarTerminos()
    {
        foreach (var ListaAtomos in ListTerminos)
        {
            foreach (var atomo in ListaAtomos)
            {
                Console.Write(atomo.NombreAtomo + " ");
            }
            Console.WriteLine();
        }
    }
}