using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IDN.Core.DomainObject;

public class ValidationEntity
{
    private readonly List<string> _erros = new();

    public IReadOnlyCollection<string> Erros => _erros.AsReadOnly();
    public bool IsValid => _erros.Count == 0;

    public ValidationEntity NotNullOrEmpty(string? value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            _erros.Add(message);

        return this;
    }

    public ValidationEntity HasMinLen(string? value, int min, string message)
    {
        if ((value ?? string.Empty).Trim().Length < min)
            _erros.Add(message);

        return this;
    }

    public ValidationEntity HasMaxLen(string? value, int max, string message)
    {
        if ((value ?? string.Empty).Trim().Length > max)
            _erros.Add(message);

        return this;
    }

    public ValidationEntity IsEmail(string? value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            _erros.Add(message);
            return this;
        }

        var pattern = "^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$";
        if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
            _erros.Add(message);

        return this;
    }

    public ValidationEntity AreEquals(string? a, string? b, string message)
    {
        if (object.Equals(a, b))
            _erros.Add(message);

        return this;
    }


    public ValidationEntity IsGreaterOrEqualsThan(decimal value, decimal comparer, string message)
    {
        if (value < comparer)
            _erros.Add(message);
        return this;
    }

    public ValidationEntity IsBetween(int value, int min, int max, string message)
    {
        if (value < min || value > max)
            _erros.Add(message);
        return this;
    }

    public ValidationEntity Matches(string? value, string pattern, string message)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, pattern))
            _erros.Add(message);
        return this;
    }

    /// <summary>
    /// Lança uma exceção com as mensagens acumuladas (opcional).
    /// </summary>
    public void ThrowIfInvalid()
    {
        if (_erros.Count > 0)
            throw new InvalidOperationException(string.Join("; ", _erros));
    }
}
