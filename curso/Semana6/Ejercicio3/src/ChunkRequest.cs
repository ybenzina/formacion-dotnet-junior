using System;

// Representa una parte de descarga.
public class ChunkRequest
{
    public Uri Uri { get; init; }
    public string Destination { get; init; }
    public int PartIndex { get; init; }
    public int TotalParts { get; init; }
    public int Attempt { get; set; }


    public ChunkRequest(Uri uri, string destination, int partIndex, int totalParts)
    {
        Uri = uri;
        Destination = destination;
        PartIndex = partIndex;
        TotalParts = totalParts;
        Attempt = 0;
    }
}