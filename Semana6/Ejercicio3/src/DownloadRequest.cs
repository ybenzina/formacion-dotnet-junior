using System;


// Peticion de descarga por fichero
public record DownloadRequest(Uri Uri, string Destination, int Parts);