using Nancy;
using CD.Objects;
using System.Collections.Generic;

namespace CD.Objects
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/cds"] = _ => {
        List<CD> allCDs = CD.GetAll();
        return View["cds.cshtml", allCDs];
      };
      Get["/cds/new"] = _ => {
        return View["cd_form.cshtml"];
      };
      Get["/artists"] = _ => {
        List<Artist> allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/new"] = _ => {
        return View["artist_form.cshtml"];
      };
      Post["/cds"] = _ => {
        CD newCD = new CD(Request.Form["cd-name"]);
        List<CD> allCDs = CD.GetAll();
        return View["cds.cshtml", allCDs];
      };
      Post["/artists"] = _ => {
        Artist newArtist = new Artist(Request.Form["artist-name"]);
        List<Artist> allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
    }
  }
}
