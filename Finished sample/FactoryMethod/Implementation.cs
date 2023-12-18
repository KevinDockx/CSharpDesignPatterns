namespace FactoryMethod;

/// <summary>
/// Product
/// </summary>
public abstract class DiscountService
{
    public abstract int DiscountPercentage { get; }
    public override string ToString() => GetType().Name;

}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CountryDiscountService(string countryIdentifier) : DiscountService
{
    private readonly string _countryIdentifier = countryIdentifier;

    public override int DiscountPercentage
    {
        get
        {
            return _countryIdentifier switch
            {
                // if you're from Belgium, you get a better discount :)
                "BE" => 20,
                _ => 10,
            };
        }
    }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CodeDiscountService(Guid code) : DiscountService
{
    private readonly Guid _code = code;

    public override int DiscountPercentage
    {
        // each code returns the same fixed percentage, but a code is only 
        // valid once - include a check to so whether the code's been used before
        // ... 
        get => 15;
    }
}

/// <summary>
/// Creator
/// </summary>
public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CountryDiscountFactory(string countryIdentifier) : DiscountFactory
{
    private readonly string _countryIdentifier = countryIdentifier;

    public override DiscountService CreateDiscountService()
    {
        return new CountryDiscountService(_countryIdentifier);
    }
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CodeDiscountFactory(Guid code) : DiscountFactory
{
    private readonly Guid _code = code;

    public override DiscountService CreateDiscountService()
    {
        return new CodeDiscountService(_code);
    }
}
