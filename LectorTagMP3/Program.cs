using System.IO;
using System.Text;
using EspacioTag;


string direccionArchivo;

while (true)
{
    Console.Write("Ingrese la direccion del archivo mp3 que quiere analizar: ");
    direccionArchivo = Console.ReadLine();

    if (!File.Exists(direccionArchivo))
    {
        Console.WriteLine("\nEl archivo ingresado no existe.\nIngrese una direccion valida.\n");
        continue;
    } 
    
    if (Path.GetExtension(direccionArchivo).ToLower() != ".mp3")
    {
        Console.WriteLine("\nEl archivo ingresado no es de extension .mp3.\nIngrese un archivo valido.\n");
        continue;
    }

    break;
} 

using (FileStream archivo = new FileStream(direccionArchivo, FileMode.Open, FileAccess.Read))
using (BinaryReader ArchivoBinario = new BinaryReader(archivo))
{
    archivo.Seek(-128, SeekOrigin.End);

    byte[] tag = ArchivoBinario.ReadBytes(128); // aqui se almacena la etiqueta, conformada por los ultimos 128 bytes del archivo

    string cadena = Encoding.GetEncoding("latin1").GetString(tag, 0, 3);
    if (cadena != "TAG")
    {
        Console.WriteLine("Este archivo no contiene un tag ID3v1 valido.");
    } else
    {
        Id3v1Tag datosCancion = new Id3v1Tag(tag);

        Console.WriteLine("Información de la cancion:\n");
        Console.WriteLine($"Nombre: {datosCancion.Titulo}");
        Console.WriteLine($"Artista: {datosCancion.Artista}");
        Console.WriteLine($"Album: {datosCancion.Album}");
        Console.WriteLine($"Anio: {datosCancion.AnioCancion}");
    }

}