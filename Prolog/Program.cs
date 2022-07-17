
using Prolog.Arbol;
using Prolog.Consulta;
using Prolog.LecturaArchivo;



Interprete lecturaArchivo = new Interprete("documento.txt");
Arbol a = new Arbol(lecturaArchivo);
//a.Imprimir(a.getClausulas(),0);

//Console.WriteLine("Escriba la consulta : ");
//string? texto = Console.ReadLine();
//Console.WriteLine(texto);
Consulta c = new Consulta(a);
Console.WriteLine(c.EncadenamientoHaciaAtras("hermanode('Juan','Maria')"));