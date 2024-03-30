using System.Runtime.Serialization;

namespace RFLOT.Application.Models;

public class OneZoneInfo
{
    public List<string> Spaces { get; set; }
    public int CountSpaces => Spaces.Count;
    
    public string Name { get; set; }
}