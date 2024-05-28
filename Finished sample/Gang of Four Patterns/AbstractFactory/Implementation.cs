namespace AbstractFactory;

/// <summary>
/// AbstractFactory
/// </summary>
public interface IShoppingCartPurchaseFactory
{
    IDiscountService CreateDiscountService();
    IShippingCostsService CreateShippingCostsService();
}

/// <summary>
///  AbstractProduct
/// </summary>
public interface IDiscountService
{
    int DiscountPercentage { get; }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class BelgiumDiscountService : IDiscountService
{
    public int DiscountPercentage => 20;
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class FranceDiscountService : IDiscountService
{
    public int DiscountPercentage => 10;
}


/// <summary>
///  AbstractProduct
/// </summary>
public interface IShippingCostsService
{
    decimal ShippingCosts { get; }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class BelgiumShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 20;
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class FranceShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 25;
}


/// <summary>
/// ConcreteFactory
/// </summary>
public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new BelgiumDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new BelgiumShippingCostsService();
    }
}

/// <summary>
/// ConcreteFactory
/// </summary>
public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new FranceDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new FranceShippingCostsService();
    }
}

/// <summary>
/// Client class 
/// </summary>
public class ShoppingCart(IShoppingCartPurchaseFactory factory)
{
    private readonly IDiscountService _discountService = factory.CreateDiscountService();
    private readonly IShippingCostsService _shippingCostsService = factory.CreateShippingCostsService();
    private readonly int _orderCosts = 200;

    public void CalculateCosts()
    {
        Console.WriteLine($"Total costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
    }
}
