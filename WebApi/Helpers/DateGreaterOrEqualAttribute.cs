using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApi.Helpers;
public class DateGreaterOrEqualAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterOrEqualAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var currentValue = (DateTime)value;
        var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (comparisonProperty == null)
        {
            return new ValidationResult($"Unknown property: {_comparisonProperty}");
        }

        var comparisonValue = (DateTime)comparisonProperty.GetValue(validationContext.ObjectInstance);

        if (currentValue < comparisonValue)
        {
            return new ValidationResult(ErrorMessage ?? $"The {validationContext.MemberName} must be greater or equal to {_comparisonProperty}.");
        }

        return ValidationResult.Success;
    }
}
