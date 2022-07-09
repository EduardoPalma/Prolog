// See https://aka.ms/new-console-template for more information

using Prolog.Arbol;
using Prolog.LecturaArchivo;
using Prolog.Objetos;

/*
// es un hecho de asume que no tiene mas hijos
Clausula c1 = new Hecho("padrede");
// es una regla debe contener hijos ya sea, Hechos o reglas
// para este caso c2 contieene un hecho "c1"
Clausula c2 = new Regla("hijode");
Regla c2h = (Regla)c2;
c2h.ListaClausulas.Add(c1);

//mismo caso que el anterior pero ahora c3 contiene una 1 regla y 1 hecho
Clausula c3 = new Regla("hermanode");
Regla c3r = (Regla)c3;
c3r.ListaClausulas.Add(c1);
c3r.ListaClausulas.Add(c2);


// familiarde contiene en este caso hermanode 
Clausula c4 = new Regla("familiarde");
Regla c4r = (Regla)c4;
c4r.ListaClausulas.Add(c3);
c4r.ListaClausulas.Add(c1);
c4r.ListaClausulas.Add(c2);

List<Clausula> list = new List<Clausula>();
list.Add(c4);
Arbol a = new Arbol(list);
a.Imprimir(list);
*/


LecturaArchivo lecturaArchivo = new LecturaArchivo("documento.txt");
