using System.Collections.Generic;

namespace AlbumOrganizer.Objects
{
  public class Artist
  {
    private string _name;
    private int _id;
    private List<Album> _albums = new List<Album>{};

    private static List<Artist> _instances = new List<Artist>{};

    public Artist(string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetId()
    {
      return _id;
    }
    public void AddAlbum(Album newAlbum)
    {
      _albums.Add(newAlbum);
    }
    public static List<Artist> GetAll()
    {
      return _instances;
    }
    public static Artist Find(int searchID)
    {
      return _instances[searchID - 1];
    }
    public static List<int> ArtistExists(string searchArtistName)
    {
      List<int> result = new List<int>{};
      foreach(Artist artist in _instances)
      {
        if (artist.GetName() == searchArtistName)
        {
          result.Add(artist._id);
        }
      }
      return result;
    }
  }
}
