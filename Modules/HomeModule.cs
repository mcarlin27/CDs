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
      Post["/cds"] = _ => {
        CD newCD = new CD(Request.Form["cd-name"]);
        List<CD> allCDs = CD.GetAll();
        return View["cds.cshtml", allCDs];
      };
    }
  }
}
