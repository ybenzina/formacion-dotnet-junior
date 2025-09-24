public class DownloadManagerOptions
{
    public int MaxConcurrentDownloads { get; init; } = 2;
    public int MaxConcurrentPartsPerFile { get; init; } = 4;
    public int MaxRetriesPerPart { get; init; } = 3;
    public bool UseChannelPipeline { get; init; } = false; // si es true usa Channel pipeline, y sino usa BlockingCollection
}