# Power of Data Structures: Trees

## Welcome to the Trees Tutorial
- [Welcome](0-welcome.md)
- [Linked List](2-Linked-List.md)
- [Tree](3-Tree.md)
- [Demo video COMMING SOON]<!-- add youtube link for Queue tutorial -->

# IV. Trees: Building Your Music Library

## Introduction to Trees
In computer science, a tree is a widely used abstract data type (ADT) that simulates a hierarchical tree structure, with a root value and subtrees of children with a parent node, represented as a set of linked nodes. Each node contains a value or data, and it may or may not have a child node.

Just as a tree has branches, a tree data structure has nodes, each of which can point to two or more nodes. The node without a parent is the root of the tree, and nodes without children are called leaves.

<img src="./Images/Treedatastructure.png">

<i><font size="2" color="grey">Figure: Diagram of a Tree Data Structure Geekforgeeks.org</font></i>

In the context of a music streaming service, trees could be used to structure the music library. Each genre might be a root node, with various artists as child nodes. These artist nodes could then have album nodes, and finally, the song nodes.

Trees provide an efficient way to search, insert and delete items in a collection. Each node's position in the tree tells us something about its features. In our music library example, knowing an artist node's parent helps us identify its genre, and its children help us identify their albums.

## Common Tree Operations and Efficiency
Tree data structures are excellent for several reasons:
* `Insertion`: Adding a song to the music library (tree) can be done efficiently. This operation has a time complexity of O(log n) if the tree is balanced.
    1. Starting from the root node (the genre), traverse down the tree to find the appropriate artist.
    2. From the artist, traverse to find the right album.
    3. Add the song to the album node.
    4. If any of the nodes (artist or album) doesn't exist, create a new node and add the song.
* `Searching`: Finding a song in the library can also be done efficiently with a time complexity of O(log n) if the tree is balanced.
    1. Starting from the root node, traverse down the tree following the nodes that lead to the song.
    2. If a matching song is found, return the song.
    3. If no match is found after traversing the entire tree, return 'Song not found'.
* `Deletion`: Removing a song from the library involves locating the song and then removing it. This operation has a time complexity of O(log n) if the tree is balanced.
    1. Locate the song in the tree (similar to the search operation).
    2. Once the song is located, remove it from its parent node (album).
    3. If the parent node has no remaining children (no more songs in the album), the parent node can be removed as well.

## Accessing a Song with Trees
To access a song in a tree, we start at the root of the tree and traverse through the branches (nodes), following the path that leads to the desired song. This method of accessing data is efficient and intuitive in a hierarchical structure like our music library.

## Example: Creating a Tree using Node Structure
Here we create our Node class with an `artist` property, a `songs` list to hold the songs, and a `children` list to hold the nodes for albums.
```csharp
public class MusicNode
{
    public string Artist { get; set; }
    public List<string> Songs { get; set; }
    public List<MusicNode> Children { get; set; }

    public MusicNode(string artist)
    {
        Artist = artist;
        Songs = new List<string>();
        Children = new List<MusicNode>();
    }
}
```
To add an artist to the library (root of the tree), we simply create a new node.

```csharp
public class MusicLibrary
{
    private List<MusicNode> roots;

    public MusicLibrary()
    {
        roots = new List<MusicNode>();
    }

    public void AddArtist(string artist)
    {
        var newNode = new MusicNode(artist);
        roots.Add(newNode);
    }
}

```

We can add an album by adding a child node to the appropriate artist node.

```csharp
public void AddAlbum(string artist, string album)
{
    foreach (var artistNode in roots)
    {
        if (artistNode.Artist == artist)
        {
            var albumNode = new MusicNode(album);
            artistNode.Children.Add(albumNode);
            return;
        }
    }
    Console.WriteLine("Artist not found in library.");
}

```

Similarly, we can add a song by locating the appropriate album and adding the song to its song list.

```csharp
public void AddSong(string artist, string album, string song)
{
    foreach (var artistNode in roots)
    {
        if (artistNode.Artist == artist)
        {
            foreach (var albumNode in artistNode.Children)
            {
                if (albumNode.Artist == album)
                {
                    albumNode.Songs.Add(song);
                    return;
                }
            }
            Console.WriteLine("Album not found for this artist.");
            return;
        }
    }
    Console.WriteLine("Artist not found in library.");
}

```

### Problem to Solve: Finding a Song
Create a function that traverses the tree and finds a song in the music library. It should print and return the path to the song if found, and print an error message and return null if not found.

```csharp
public class MusicNode
{
    public string Artist { get; set; }
    public List<string> Songs { get; set; }
    public List<MusicNode> Children { get; set; }
    
    //...
}

public class MusicLibrary
{
    private List<MusicNode> roots;

    //...

    public string FindSong(string song)
    {
        // Your task is to implement the FindSong function. 
        // You will need to traverse the tree starting from the root nodes in the roots list, 
        // and for each node, check the Songs list to see if the song is there. 
        // If the song is found, you should return a string representing the path to the song in the format "Artist > Album > Song". 
        // If the song is not found after traversing the entire tree, you should return null.
    }
}

```

### Conclusion
As you can see, trees are a powerful data structure for representing hierarchical relationships. They are commonly used in many applications including file systems, databases, and even in artificial intelligence for decision-making processes.

In the context of a music library, they provide a highly efficient way to store and access songs, artists, and albums, making them ideal for use in music streaming applications.
<details>
  <summary>Solution</summary>

```csharp
public class MusicNode
{
    public string Artist { get; set; }
    public List<string> Songs { get; set; }
    public List<MusicNode> Children { get; set; }
    
    //...
}

public class MusicLibrary
{
    private List<MusicNode> roots;

    //...

    public string FindSong(string song)
    {
        foreach (var artistNode in roots)
        {
            foreach (var albumNode in artistNode.Children)
            {
                if (albumNode.Songs.Contains(song))
                {
                    return $"{artistNode.Artist} > {albumNode.Artist} > {song}";
                }
            }
        }
        Console.WriteLine("Song not found in library.");
        return null;
    }
}

```
</details>
