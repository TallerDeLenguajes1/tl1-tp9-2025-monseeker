using System.IO;
using System.Text;

namespace EspacioTag;

public class Id3v1Tag
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public string AnioCancion { get; set; }


    public Id3v1Tag(byte[] tag)
    {
        Titulo = Encoding.GetEncoding("latin1").GetString(tag, 3, 30).TrimEnd('\0', ' ');
        Artista = Encoding.GetEncoding("latin1").GetString(tag, 33, 30).TrimEnd('\0', ' ');
        Album = Encoding.GetEncoding("latin1").GetString(tag, 63, 30).TrimEnd('\0', ' ');
        AnioCancion = Encoding.GetEncoding("latin1").GetString(tag, 93, 4).TrimEnd('\0', ' ');
    }
}