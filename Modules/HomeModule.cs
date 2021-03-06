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
      Get["/artists"] = _ => {
        List<Artist> allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/new"] = _ => {
        return View["artist_form.cshtml"];
      };
      Post["/cds"] = _ => {
        Artist selectedArtist = Artist.Find(Request.Form["artist-id"]);
        CD newCD = new CD(Request.Form["cd-name"], selectedArtist.GetName());
        selectedArtist.AddCD(newCD);
        newCD.SetArtist(selectedArtist.GetName());
        List<CD> allCDs = CD.GetAll();
        return View["cds.cshtml", allCDs];
      };
      Post["/artists"] = _ => {
        Artist newArtist = new Artist(Request.Form["artist-name"]);
        List<Artist> allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameters.id);
        List<CD> artistCDs = selectedArtist.GetCDs();
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCDs);
        return View["artist_disco.cshtml", model];
      };
      Get["/artists/{id}/cds/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameters.id);
        List<CD> artistCDs = selectedArtist.GetCDs();
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCDs);
        return View["artist_cd_form.cshtml", model];
      };
      Post["/cds"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(Request.Form["artist-id"]);
        string artistName = selectedArtist.GetName();
        List<CD> artistDisco = selectedArtist.GetCDs();
        string cdName = Request.Form["cd-name"];
        CD newCD = new CD(cdName, artistName);
        artistDisco.Add(newCD);
        model.Add("cds", artistDisco);
        model.Add("artist", selectedArtist);
        return View["artist_disco.cshtml", model];
      };
      Get["/search-artist"] = _ => {
        return View["search_function.cshtml"];
      };
      Post["/search-artist"] = _ => {
        List<CD> allCDs = CD.GetAll();
        List<CD> displayCD = new List<CD>();
        string userSearch = Request.Form["search-CD"];
        foreach (CD cd in allCDs)
        {
          if ((cd.GetDescription().Contains(userSearch)) == true) {
            displayCD.Add(cd);
          }
        }
        return View["search_results.cshtml", displayCD];
      };
    }
  }
}
