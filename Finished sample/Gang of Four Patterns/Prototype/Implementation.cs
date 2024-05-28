using System.Text.Json;

namespace Prototype;

/// <summary>
/// Prototype
/// </summary>
public abstract class Person
{
    public abstract string Name { get; set; }

    public abstract Person Clone(bool deepClone);
}

/// <summary>
/// ConcretePrototype1
/// </summary>
public class Manager(string name) : Person
{
    public override string Name { get; set; } = name;

    public override Person Clone(bool deepClone = false)
    {
        if (deepClone)
        {     
            var objectAsJson = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Manager>(objectAsJson); 
        }

        return (Person)MemberwiseClone();
    }
}

/// <summary>
/// ConcretePrototype2
/// </summary>
public class Employee(string name, Manager manager) : Person
{
    public Manager Manager { get; set; } = manager;
    public override string Name { get; set; } = name;

    public override Person Clone(bool deepClone = false)
    {   
        if (deepClone)
        {
            var objectAsJson = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Employee>(objectAsJson);
        }
        return (Person)MemberwiseClone();
    }
}