using System.IO;

string direccionDirectorio;

do {
    Console.Write("Ingrese la direccion del directorio: ");
    direccionDirectorio = Console.ReadLine();

    if (!Directory.Exists(direccionDirectorio))
    {
        Console.WriteLine("\nEl directorio ingresado no existe.\nIngrese una direccion valida.");
    }

} while (!Directory.Exists(direccionDirectorio));

string[] carpetasDeDirectorio = Directory.GetDirectories(direccionDirectorio);
string[] archivosDelDirectorio = Directory.GetFiles(direccionDirectorio);

if (carpetasDeDirectorio.Length != 0)
{
    Console.WriteLine("Carpetas encontradas en el directorio:");
    foreach (string carpeta in carpetasDeDirectorio)
    {
        string subcarpeta = Path.GetFileName(carpeta);
        Console.WriteLine(subcarpeta);
    }
}
else
{
    Console.WriteLine("No existen carpetas en esta direccion.\n");
}

if (archivosDelDirectorio.Length != 0)
{
    Console.WriteLine("\nArchivos encontrados en el directorio:");
    foreach (var archivo in archivosDelDirectorio)
    {
        FileInfo file = new FileInfo(archivo);
        Console.WriteLine($"{file.Name}\t{Math.Round(file.Length / 1024.0, 2):F2} KB");
    }
}
else
{
    Console.WriteLine("No existen archivos en esta direccion.\n");
}


List<string> datosDeArchivo = new List<string>();
datosDeArchivo.Add("Nombre,Tamanio (KB),Fecha de ultima modificacion");

foreach (var archivo in archivosDelDirectorio)
{
    FileInfo file = new FileInfo(archivo);
    string nombre = file.Name;
    double tamanio = Math.Round(file.Length / 1024.0, 2);
    string ultimaModificacion = file.LastWriteTime.ToString("dd/MM/yyyy HH:mm");

    string linea = $"{nombre},{tamanio:F2},{ultimaModificacion}";
    datosDeArchivo.Add(linea);
}


string nombreArchivoCSV = "reporte_archivos.csv";
string direccionArchivoCSV = Path.Combine(direccionDirectorio, nombreArchivoCSV);
File.WriteAllLines(direccionArchivoCSV, datosDeArchivo);

if (File.Exists(direccionArchivoCSV))
{
    Console.WriteLine("\nArchivo creado exitosamente.\n");
}
else
{
    Console.WriteLine("\nHa ocurrido un problema. No se pudo crear el archivo.\nIntentalo de nuevo mas tarde.");
}