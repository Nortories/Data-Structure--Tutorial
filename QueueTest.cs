using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class SongRequestHandlerTest
{
    private SongRequestHandler handler;
    
    [SetUp]
    public void SetUp()
    {
        handler = new SongRequestHandler();
    }

    [Test]
    public void TestSongRequests()
    {
        // Adding VIP and regular song requests
        handler.AddRequest(new SongRequest() { User = "User1", IsVip = true, Song = "Song1" });
        handler.AddRequest(new SongRequest() { User = "User2", IsVip = false, Song = "Song2" });
        handler.AddRequest(new SongRequest() { User = "User3", IsVip = true, Song = "Song3" });
        handler.AddRequest(new SongRequest() { User = "User4", IsVip = false, Song = "Song4" });

        // Creating a list to store played songs
        List<string> playedSongs = new List<string>();
        
        // Playing songs until no more requests
        while(true)
        {
            SongRequest song = handler.PlayNextSong();
            if(song == null)
            {
                break;
            }
            playedSongs.Add(song.Song);
        }

        // Asserting that the songs were played in the expected order
        Assert.AreEqual(playedSongs, new List<string>() { "Song1", "Song3", "Song2", "Song4" });
    }
}