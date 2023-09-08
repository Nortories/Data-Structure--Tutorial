using NUnit.Framework;

[TestFixture]
public class SongLinkedListTests
{
    private SongLinkedList playlist;

    [SetUp]
    public void Setup()
    {
        playlist = new SongLinkedList();
    }

    [Test]
    public void AddSong_WithEmptyPlaylist_ShouldSetHeadAndTail()
    {
        // Arrange
        string song = "Song 1";

        // Act
        playlist.AddSong(song);

        // Assert
        Assert.AreEqual(song, playlist.Head.Song);
        Assert.AreEqual(song, playlist.Tail.Song);
        Assert.IsNull(playlist.Head.Prev);
        Assert.IsNull(playlist.Tail.Next);
    }

    [Test]
    public void AddSong_WithExistingPlaylist_ShouldAddSongAtEnd()
    {
        // Arrange
        playlist.AddSong("Song 1");
        playlist.AddSong("Song 2");
        string newSong = "Song 3";

        // Act
        playlist.AddSong(newSong);

        // Assert
        Assert.AreEqual(newSong, playlist.Tail.Song);
        Assert.AreEqual(newSong, playlist.Tail.Prev.Next.Song);
    }

    [Test]
    public void SetLoop_WithLoopEnabled_ShouldMakePlaylistCircular()
    {
        // Arrange
        playlist.AddSong("Song 1");
        playlist.AddSong("Song 2");

        // Act
        playlist.SetLoop(true);

        // Assert
        Assert.AreEqual(playlist.Head, playlist.Tail.Next);
    }

    [Test]
    public void SetLoop_WithLoopDisabled_ShouldBreakPlaylistCircle()
    {
        // Arrange
        playlist.AddSong("Song 1");
        playlist.AddSong("Song 2");
        playlist.SetLoop(true);

        // Act
        playlist.SetLoop(false);

        // Assert
        Assert.IsNull(playlist.Tail.Next);
    }
}