using Nancy;
using System.Collections.Generic;
using AlbumOrganizer.Objects;

namespace AlbumOrganizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Album> allAlbums = Album.GetAll();
        return View["index.cshtml", allAlbums];
      };
      Get["/album/new"] = _ => View["album_new_form.cshtml"];
      Get["/artist_search_form"] = _ => View["artist_search_form.cshtml"];
      Post["/"] = _ => {
        string title = Request.Form["new-album-title"];
        string artist = Request.Form["new-album-artist"];
        Album newAlbum = new Album(title, artist);

        List<int> matchedArtists = Artist.ArtistExists(artist);
        if (matchedArtists.Count > 0)
        {
          Artist foundArtist = Artist.Find(matchedArtists[0]);
          foundArtist.AddAlbum(newAlbum);
        }
        else
        {
          Artist newArtist = new Artist(artist);
          newArtist.AddAlbum(newAlbum);
        }
        List<Album> allAlbums = Album.GetAll();
        return View["index.cshtml", allAlbums];
      };
      Get["/artist"] = _ = {
        string searchedArtist = Request.Form["artist-name"];
        List<Artist> artistContained = Artist.SearchArtist(searchedArtist);
        return View["search_result.cshtml", artistContained];
      }
    }
  }
}
