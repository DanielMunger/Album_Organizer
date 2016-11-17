using System.Collections.Generic;

namespace AlbumOrganizer.Objects
{
  public class Album
  {
    private string _title;
    private string _artist;
    private int _id;

    private static List<Album> _instances = new List<Album>{};

    public Album(string title, string artist)
    {
      _title = title;
      _artist = artist;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }
    public string GetTitle()
    {
      return _title;
    }
    public void SetArtist(string newArtist)
    {
      _artist = newArtist;
    }
    public string GetArtist()
    {
      return _artist;
    }
    public int GetId()
    {
      return _id;
    }
    public static Album Find(int searchID)
    {
      return _instances[searchID-1];
    }
    public static List<Album> GetAll()
    {
      return _instances;
    }
  }
}
