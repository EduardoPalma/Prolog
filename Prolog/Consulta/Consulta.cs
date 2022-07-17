using System.Text.RegularExpressions;
using Prolog.LecturaArchivo;
using Prolog.Objetos;

namespace Prolog.Consulta;

public class Consulta
{
    private Arbol.Arbol arbol;
    public Consulta(Arbol.Arbol i)
    {
        arbol = i;
    }
    
    public Boolean EncadenamientoHaciaAdelante(string consulta)
    {
        /*
         * abuelode(pedro,juan).
         * buscar la regla o hecho
         */
        return true;
    }
    public Boolean EncadenamientoHaciaAtras(string consulta)
    {
        Consult consult = Interprete.ValidarConsulta(consulta);
        Clausula clausula = BuscarConsulta(consult.Name,consult.ListTerminos.Count);
        if (clausula != null)
        {
            Console.WriteLine();
            return EncadenamientoHaciaAtras(consult.ListTerminos, clausula);
        }
        else
        {
            Console.WriteLine("No Existe "+consulta);
        }
        return false;
    }

    private Boolean EncadenamientoHaciaAtras(List<Termino> terminos,Clausula c)
    {
        if (c is Hecho)
        {
            return Existe(terminos, c);
        }
        else
        {
            for (int i = 0; i < c.ListaClausulas.Count; i++)
            {
                var terminosNuevos = Unificacion(terminos,c.ListTerminos[0],c.ListaTerminoCLausulas[i]);
                if (!EncadenamientoHaciaAtras(terminosNuevos, c.ListaClausulas[i])) return false;
                
            }
            
            //Console.WriteLine(c.Name);
        }
        return true;
    }

    private Boolean Existe(List<Termino> terminos, Clausula c)
    {
        foreach (var Terminos in c.ListTerminos)
        {
            int i;
            for (i = 0; i < Terminos.Count; i++)
            {
                if (!Terminos[i].Name.Equals(terminos[i].Name))
                {
                    break;
                }
            }

            if (i == Terminos.Count) return true;
            return false;
        }

        return false;
    }

    public Clausula BuscarConsulta(string consulta, int tam)
    {
        return BuscarConsulta(consulta, arbol.Clausulas,tam);
    }

    private static Clausula BuscarConsulta(string consulta,List<Clausula> clausulas, int tam)
    {
        if (clausulas.Count > 0)
        {
            foreach (var terminos in clausulas)
            {
                if (terminos.Name.Equals(consulta) && tam == terminos.ListTerminos[0].Count)
                {
                    return terminos;
                }

                Clausula c = BuscarConsulta(consulta, terminos.ListaClausulas, terminos.ListTerminos[0].Count);
                if (c != null) return c;

            }
            return null!;
        }
        return null!;
    }

    private List<Termino> Unificacion(List<Termino> terminosConsulta,List<Termino> terminosRegla,List<Termino> terminosValidos)
    {
        List<Termino> nuevosTerminos = new List<Termino>();
        foreach (var termino in terminosValidos)
        {
            Boolean encontro = false;
            for (int i = 0; i < terminosRegla.Count; i++)
            {
                if (termino.Name.Equals(terminosRegla[i].Name))
                {
                    Termino t = new Variable(terminosConsulta[i].Name);
                    nuevosTerminos.Add(t);
                    encontro = true;
                }
            }

            if (!encontro)
            {
                Termino t = new Variable(termino.Name);
                nuevosTerminos.Add(t);
            }
        }
        foreach (var termino in nuevosTerminos)
        {
            Console.Write(termino.Name + " ");
        }
        Console.WriteLine();
        return nuevosTerminos;
    }
    
}