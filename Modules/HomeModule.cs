using Nancy;
using System.Collections.Generic;

namespace AlbumOrganizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      //Insert your GETs and POSTs here
    }
  }
}
