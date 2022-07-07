
using System.Text.RegularExpressions;
using Prolog.Objetos;

namespace Prolog.LecturaArchivo;

public class LecturaArchivo
{
    private String _path;

    public LecturaArchivo(String path)
    {
        _path = path;
        LeerArchivo();
    }

    private void LeerArchivo()
    {
        StreamReader archivo = new StreamReader(_path);
        while (!archivo.EndOfStream)
        {
            Console.WriteLine(Convert.ToString(archivo.Read()));
        }
    }

    private List<String> SacarTerminos(string variables)
    {
        String [] listChar = {"(",")","'"," "};
        List<String> terminos = new List<string>();
        if (variables.Contains(","))
        {
            variables = Regex.Replace(variables, "[()' ]", String.Empty);
            Console.WriteLine(variables);
        }
        else
        {
            variables = Regex.Replace(variables,"[()']",String.Empty);
            Console.WriteLine(variables);
        }
        
        return terminos;
    }
}