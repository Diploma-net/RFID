namespace RFLOT.Application.Zone.Models;

public class ZonesInfo
{
    public Guid IdZone { get; set; }
    public string Name { get; set; }
    public string Progress { get; set; }
    public List<string>? FullNameChecker { get; set; }
    
}