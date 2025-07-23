// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Collections.Generic;

string rutaDeArchivo = @"C:\Users\CYNTHIA\OneDrive\Documentos\archivo.txt";

if (File.Exists(rutaDeArchivo))
{
    FileStream FsStream = new FileStream(rutaDeArchivo, FileMode.Open);
    StreamReader Streamer = new StreamReader(FsStream);

    string linea;
    do
    {
        linea = Streamer.ReadLine();
        Console.WriteLine(linea);

    } while (linea != null);

    Streamer.Close();
}
else
{
    Console.WriteLine("Archivo no encontrado");
}