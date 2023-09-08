public class SongRequest
{
    public string User { get; set; }
    public bool IsVip { get; set; }
    public string Song { get; set; }
}

public class SongRequestHandler
{
    private Queue<SongRequest> vipSongRequests = new Queue<SongRequest>();
    private Queue<SongRequest> regularSongRequests = new Queue<SongRequest>();

    public void AddRequest(SongRequest request)
    {
        if (request.IsVip)
        {
            vipSongRequests.Enqueue(request);
            Console.WriteLine($"Added VIP song request: {request.Song} by {request.User}");
        }
        else
        {
            regularSongRequests.Enqueue(request);
            Console.WriteLine($"Added regular song request: {request.Song} by {request.User}");
        }
    }

    public SongRequest PlayNextSong()
    {
        if (vipSongRequests.Count > 0)
        {
            SongRequest nextVipRequest = vipSongRequests.Dequeue();
            Console.WriteLine($"Playing VIP song: {nextVipRequest.Song} requested by {nextVipRequest.User}");
            return nextVipRequest;
        }
        else if (regularSongRequests.Count > 0)
        {
            SongRequest nextRegularRequest = regularSongRequests.Dequeue();
            Console.WriteLine($"Playing regular song: {nextRegularRequest.Song} requested by {nextRegularRequest.User}");
            return nextRegularRequest;
        }
        else
        {
            Console.WriteLine("No more song requests.");
            return;
        }
    }
}