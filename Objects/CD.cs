using System.Collections.Generic;

namespace CD.Objects
{
  public class CD
  {
    private string _description;
    private string _artist;
    private int _id;
    private static List<CD> _instances = new List<CD> {};
    public CD (string description, string artist)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
      _artist = artist;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription (string newDescription)
    {
      _description = newDescription;
    }
    public static List<CD> GetAll()
    {
      return _instances;
    }
    public int GetId()
    {
      return _id;
    }
    public bool Contains(string value)
    {
      return true;
    }
    public string GetArtist()
    {
      return _artist;
    }
    public void SetArtist (string newArtist)
    {
      _artist = newArtist;
    }
    public static CD Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
