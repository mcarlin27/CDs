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
      Get["/cds/new"] = _ => {
        return View["cd_form.cshtml"];
      };
    }
  }
}
