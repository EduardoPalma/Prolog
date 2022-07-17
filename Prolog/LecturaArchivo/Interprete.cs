
using System.Text.RegularExpressions;
using Prolog.Objetos;


namespace Prolog.LecturaArchivo;

public class Interprete
{
    private String _path;
    public List<Hecho> ListaHechos { get; set; }
    public List<Regla> ListaReglas { get; set; }

    public Interprete(String path)
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
    }

    private static List<Termino> SacarTerminos(string variables, int type)
    {
        List<Termino> terminos = new List<Termino>();
        if (variables.Contains(","))
        {
            variables = Regex.Replace(variables, "[()]", String.Empty);
            string[] ter = variables.Split(",");
            foreach (var termino in ter)
            {
                if (type == 0)
                {
                    Termino a = new Atomo(termino);
                    terminos.Add(a);
                }
                else
                {
                    Termino a = new Variable(termino);
                    terminos.Add(a);
                }
            }
        }
        else
        {
            variables = Regex.Replace(variables,"[()]",String.Empty);
            if (type == 0)
            {
                Termino a = new Atomo(variables);
                terminos.Add(a);
            }
            else
            {
                Termino a = new Variable(variables);
                terminos.Add(a);
            }
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
            InsertarRegla(nombreRegla,clausulas);
            

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
        if (ListaHechos.FindIndex(x => x.Name.Equals(nombre)) != -1)
        {
            Hecho hecho = ListaHechos.Find(x => x.Name.Equals(nombre))!;
            hecho.InsertarTerminos(SacarTerminos(terminos,0));
        }
        else
        {
            newHecho.InsertarTerminos(SacarTerminos(terminos,0));
            ListaHechos.Add(newHecho);
        }
    }

    private void InsertarRegla(string nombre,string clausulas)
    {
        List<string> reglaParce = NombreTerminos(nombre);
        List<Termino> variables = SacarTerminos(reglaParce[1],1);

        if (ListaReglas.FindIndex(x => x.Name.Equals(reglaParce[0])) != -1)
        {
            Regla r = ListaReglas.Find(x => x.Name.Equals(reglaParce[0]))!;
            ListaClausulasRegla(r,clausulas);
            
        }
        else
        {
            Regla r = new Regla(reglaParce[0]);
            r.InsertarVariables(variables);
            ListaClausulasRegla(r,clausulas);
            ListaReglas.Add(r);
        }
    }

    private void ListaClausulasRegla(Regla r, string clausulas)
    {
        string[] clausulasRegla = Regex.Matches(clausulas,@"[a-zZ]+\([\,[aA-zZ]*|[aA-zZ]*]\)").
            Select(m => m.Value).ToArray();
        foreach (var clau in clausulasRegla)
        {
            List<string> nombreTerminos = NombreTerminos(clau+")");
            List<Termino> Terminos = SacarTerminos(nombreTerminos[1],1);
            Hecho c = new Hecho(nombreTerminos[0]);
            c.InsertarTerminos(Terminos);
            r.InsertarClausula(c);
            r.InsertarTerminoClausulas(Terminos);
        }
    }
    private static List<string> NombreTerminos(string clausula)
    {
        
        int len = clausula.IndexOf('(');
        string nombre = clausula.Substring(0, len);
        string terminos = clausula.Substring(len);
        List<string> nombreTermino = new List<string>();
        nombreTermino.Add(nombre);
        nombreTermino.Add(terminos);
        return nombreTermino;
    }

    public static Consult ValidarConsulta(string consulta)
    {
        List<string> nombreTerminos = NombreTerminos(consulta);
        Consult c = new Consult(nombreTerminos[0], SacarTerminos(nombreTerminos[1],0));
        return c;
    }
}