
public class DownloadProgress
{
    public string Destination { get; init; }
    public int TotalParts { get; init; }
    public int CompletedParts { get; init; }
    public double Percent => TotalParts == 0 ? 100 : (CompletedParts * 100.0 / TotalParts);


    public DownloadProgress(string destination, int totalParts, int completedParts)
    {
        Destination = destination;
        TotalParts = totalParts;
        CompletedParts = completedParts;
    }
}