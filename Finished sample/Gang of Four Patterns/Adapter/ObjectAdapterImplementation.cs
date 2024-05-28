namespace Adapter;

public class CityFromExternalSystem(string name, string nickName, int inhabitants)
{
    public string Name { get; private set; } = name;
    public string NickName { get; private set; } = nickName;
    public int Inhabitants { get; private set; } = inhabitants;
}

/// <summary>
/// Adaptee
/// </summary>
public class ExternalSystem
{
    public CityFromExternalSystem GetCity()
    {
        return new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
    }
}

public class City(string fullName, long inhabitants)
{
    public string FullName { get; private set; } = fullName;
    public long Inhabitants { get; private set; } = inhabitants;
}

/// <summary>
/// Target
/// </summary>
public interface ICityAdapter
{
    City GetCity();
}

/// <summary>
/// Adapter
/// </summary>
public class CityAdapter : ICityAdapter
{
    public ExternalSystem ExternalSystem { get; private set; } = new();

    public City GetCity()
    {
        // call into the external system 
        var cityFromExternalSystem = ExternalSystem.GetCity();

        // adapt the CityFromExternalCity to a City 
        return new City(
            $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}"
            , cityFromExternalSystem.Inhabitants);
    }
}
