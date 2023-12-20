using System.Net;
using System.Text.RegularExpressions;
using FluentValidation;
using WebApiITCrona.Infrastructure.Models;

namespace WebApiITCrona.Infrastructure.Validators;

/// <summary>
/// Валидация P адреса
/// </summary>
public sealed class IpRequestValidator : AbstractValidator<IpRequest>
{
    /// <summary>
    /// ctor.
    /// </summary>

    public IpRequestValidator()
    {
        RuleFor(ip => ip.Ip)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("IP-адрес не может быть пустым")
            .NotEmpty().WithMessage("IP-адрес не может быть пустым")
            .Must(BeValidIpAddress).WithMessage("Некорректный формат IP-адреса");
    }

    private static bool BeValidIpAddress(string ip)
    {
        var pattern = "^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(?:\\.|$)){4}$";
        Regex regex = new(pattern, RegexOptions.Compiled);
        return regex.IsMatch(ip);
    }
}