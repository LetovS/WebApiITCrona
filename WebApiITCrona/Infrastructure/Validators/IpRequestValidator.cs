using System.Net;
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
        return IPAddress.TryParse(ip, out _);
    }
}