using System.Threading;
using System.Threading.Tasks;


// Interfaz para descargar un chunk, permite inyectar fallos en tests.
public interface IDownloader
{
    // Devuelve el contenido del chunk
    Task<byte[]> DownloadChunk(ChunkRequest chunkRequest, CancellationToken cancellationToken);
}