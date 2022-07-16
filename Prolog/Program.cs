
using Prolog.Arbol;
using Prolog.LecturaArchivo;



Interprete lecturaArchivo = new Interprete("prueba2.txt");
Arbol a = new Arbol(lecturaArchivo);
//a.Imprimir(a.getClausulas(),0);

Console.WriteLine("Escriba la consulta : ");
string? texto = Console.ReadLine();
Console.WriteLine(texto);
