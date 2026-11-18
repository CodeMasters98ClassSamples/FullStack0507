namespace FullStack0507.MyDomain.ValueObjects;

/// <summary>
/// Value Object
/// -> Immutable , No identity , Equality by value
/// -> Invariants (قواعد) are protected inside the object
/// </summary>
public sealed record Price : IComparable<Price>
{
    public const string DefaultCurrency = "IRR";

    public decimal Value { get; }
    public string Currency { get; }

    public Price(decimal Value, string Currency)
    {
        Init(Value, Currency);

        this.Value = Value;
        this.Currency = Currency;
    }

    private static void Init(decimal value, string currency)
    {
        if (value <= default(decimal))
            throw new Exception("لطفا قیمت را به صورت صحیح وارد نمایید.");

        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new Exception("لطفا واحد پول را به صورت صحیح وارد نمایید.");
    }

    //Factories
    public static Price Create(decimal value) => Create(value, DefaultCurrency);

    public static Price Create(decimal value, string currency) => new(value, currency.ToUpperInvariant());

    //Behaviours
    public bool IsZero => Value == default(decimal);

    public Price Add(Price other)
    {
        EnsureSameCurrency(other);
        return Create(Value + other.Value, Currency);
    }

    public Price Subtract(Price other)
    {
        EnsureSameCurrency(other);
        return Create(Value - other.Value, Currency);
    }

    public Price Multiply(int count)
    {
        if (count <= 0)
            throw new Exception("لطفا تعداد را به صورت صحیح وارد نمایید.");

        return Create(Value * count, Currency);
    }

    public int CompareTo(Price? other)
    {
        if (other is null)
            return 1;

        EnsureSameCurrency(other);
        return Value.CompareTo(other.Value);
    }

    private void EnsureSameCurrency(Price other)
    {
        if (!string.Equals(Currency, other.Currency, StringComparison.Ordinal))
            throw new Exception("امکان محاسبه بین دو واحد پول متفاوت وجود ندارد.");
    }

    //Conversions -> ease of use / persistence
    public static implicit operator decimal(Price price) => price.Value;

    public static implicit operator Price(decimal value) => Create(value);

    //Common values
    public static Price Empty => new(default(decimal), DefaultCurrency);

    public override string ToString() => $"{Value} {Currency}";
}

