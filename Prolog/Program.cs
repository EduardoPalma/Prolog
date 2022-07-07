// See https://aka.ms/new-console-template for more information

using Prolog.LecturaArchivo;
using Prolog.Objetos;


Clausula c1 = new Hecho();
Clausula c2 = new Regla();
/*
if (c1 is Hecho)
{
    Console.WriteLine("hecho");
}
*/

LecturaArchivo lecturaArchivo = new LecturaArchivo("documento.txt");
