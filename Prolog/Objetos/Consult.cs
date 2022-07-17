namespace Prolog.Objetos;

public class Consult
{
    public string Name { get; set; }
    public List<Termino> ListTerminos { get; }

    public Consult(string nombre,List<Termino> terminos)
    {
        Name = nombre;
        ListTerminos = new List<Termino>();
        InsertarTerminos(terminos);
    }

    private void InsertarTerminos(List<Termino> terminos)
    {
        foreach (var variaTermino in terminos)
        {
            ListTerminos.Add(variaTermino);
        }
    }
}