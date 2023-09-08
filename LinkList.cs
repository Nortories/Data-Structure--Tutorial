public class SongNode
{
    public string Song { get; set; }
    public SongNode Next { get; set; }
    public SongNode Prev { get; set; }
}

public class SongLinkedList
{
    private SongNode head;
    private SongNode tail;
    private bool isLooped;

    public void AddSong(string song)
    {
        var newNode = new SongNode { Song = song };

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;

        if(isLooped) // If playlist is set to loop, connect tail to head
        {
            tail.Next = head;
        }
    }

    public void SetLoop(bool enable)
    {
        isLooped = enable;
        if (enable)
        {
            if(tail != null)
            {
                tail.Next = head; // Make it circular
            }
        }
        else
        {
            if(tail != null)
            {
                tail.Next = null; // Break the circle
            }
        }
    }
}