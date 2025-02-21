namespace Wlf.Utilities.Authentication;

public class Group(string domain, string name)
{
	public string Name { get; } = name;
	public string Domain { get; } = domain;

}
