namespace Bridge;

/// <summary>
/// Abstraction
/// </summary>
public abstract class Menu(ICoupon coupon)
{
    public readonly ICoupon _coupon = coupon;
    public abstract int CalculatePrice();
}

/// <summary>
/// RefinedAbstraction
/// </summary>
public class VegetarianMenu(ICoupon coupon) : Menu(coupon)
{
    public override int CalculatePrice()
    {
        return 20 - _coupon.CouponValue;
    }
}
 
/// <summary>
/// RefinedAbstraction
/// </summary>
public class MeatBasedMenu(ICoupon coupon) : Menu(coupon)
{
    public override int CalculatePrice()
    {
        return 30 - _coupon.CouponValue;
    }
}

/// <summary>
/// Implementor
/// </summary>
public interface ICoupon
{
    int CouponValue { get; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class NoCoupon : ICoupon
{
    public int CouponValue { get => 0; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class OneEuroCoupon : ICoupon
{
    public int CouponValue { get => 1; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class TwoEuroCoupon : ICoupon
{
    public int CouponValue { get => 2; }
}