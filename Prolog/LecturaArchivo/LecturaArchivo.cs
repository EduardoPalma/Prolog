
using System.Text.RegularExpressions;
using Prolog.Objetos;


namespace Prolog.LecturaArchivo;

public class LecturaArchivo
{
    private String _path;
    private List<Hecho> ListaHechos;
    private List<Regla> ListaReglas;

    public LecturaArchivo(String path)
    {
        _path = path;
        ListaHechos = new List<Hecho>();
        ListaReglas = new List<Regla>();
        LeerArchivo();
    }

    private void LeerArchivo()
    {
        StreamReader archivo = new StreamReader(_path);
        String clausula = "";
        while (!archivo.EndOfStream)
        {
            char c = Convert.ToChar(archivo.Read());
            if (c != '.' )
            {
                clausula += c;
            }
            else
            {
                Clasificar(ElimnarCaracteresInutiles(clausula));
                clausula = "";
            }
            
        }
        /*
        foreach (var variableHecho in ListaHechos)
        {
            Console.WriteLine(variableHecho._name);
            variableHecho.MostrarTerminos();
        }*/
    }

    private List<Atomo> SacarTerminos(string variables)
    {
        List<Atomo> terminos = new List<Atomo>();
        if (variables.Contains(","))
        {
            variables = Regex.Replace(variables, "[()']", String.Empty);
            string[] ter = variables.Split(",");
            foreach (var atomo in ter)
            {
                Atomo a = new Atomo(atomo);
                terminos.Add(a);
            }
        }
        else
        {
            variables = Regex.Replace(variables,"[()']",String.Empty);
            Atomo a = new Atomo(variables);
            terminos.Add(a);
        }
        
        return terminos;
    }

    private String ElimnarCaracteresInutiles(String clausula)
    {
        return Regex.Replace(clausula, @"\s", "");
    }

    private void Clasificar(string clausula)
    {
        if (clausula.Contains(":-"))
        {
            int len1 = clausula.IndexOf(':');
            int len2 = clausula.IndexOf('-')+1;
            string nombreRegla = clausula.Substring(0, len1);
            string clausulas = clausula.Substring(len2);
            List<string> reglaParce = NombreTerminos(nombreRegla);
            List<Atomo> Variables = SacarTerminos(reglaParce[1]);
            //Console.WriteLine(reglaParce[0] + " " + Variables[0].NombreAtomo + " "+ Variables[1].NombreAtomo);
            string[] clausulasRegla = Regex.Matches(clausulas,@"[a-zZ]+\([\,[aA-zZ]*|[aA-zZ]*]\)").
                Select(m => m.Value).ToArray();
            foreach (var c in clausulasRegla)
            {
                List<string> nombreTerminos = NombreTerminos(c+")");
                Console.WriteLine(nombreTerminos[0]);
                List<Atomo> Terminos = SacarTerminos(nombreTerminos[1]);
                foreach (var atomo in Terminos)
                {
                    Console.Write(atomo.NombreAtomo+ " ");
                }
                Console.WriteLine();
            }
            

        }
        else
        {
            List<string> nombreTerminos = NombreTerminos(clausula);
            InsertarHecho(nombreTerminos[0],nombreTerminos[1]);
        }
    }

    private void InsertarHecho(string nombre, string terminos)
    {
        Hecho newHecho = new Hecho(nombre);
        if (ListaHechos.FindIndex(x => x._name.Equals(nombre)) != -1)
        {
            Hecho hecho = ListaHechos.Find(x => x._name.Equals(nombre))!;
            hecho.InsertarTerminos(SacarTerminos(terminos));
        }
        else
        {
            newHecho.InsertarTerminos(SacarTerminos(terminos));
            ListaHechos.Add(newHecho);
        }
    }

    private List<string> NombreTerminos(string clausula)
    {
        
        int len = clausula.IndexOf('(');
        string nombre = clausula.Substring(0, len);
        string terminos = clausula.Substring(len);
        List<string> nombreTermino = new List<string>();
        nombreTermino.Add(nombre);
        nombreTermino.Add(terminos);
        return nombreTermino;
    }
}