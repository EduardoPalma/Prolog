namespace Prolog.Objetos;

public class Hecho : Clausula
{
    private List<List<Termino>> ListTerminos { get; set; }

    public Hecho(string nombre)
    {
        _name = nombre;
        ListTerminos = new List<List<Termino>>();
    }

    public void InsertarTerminos(List<Termino> listaAtomos)
    {
        ListTerminos.Add(listaAtomos);
    }

    public void MostrarTerminos(string espacios)
    {
        foreach (var listaAtomos in ListTerminos)
        {
            Console.Write(espacios);
            foreach (var atomo in listaAtomos)
            {
                Atomo a = (Atomo)atomo;
                Console.Write(a.GetNombre() + " ");
            }
            Console.WriteLine();
        }
    }
    
}