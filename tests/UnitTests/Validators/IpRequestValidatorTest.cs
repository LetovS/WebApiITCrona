using FluentValidation.TestHelper;
using WebApiITCrona.Infrastructure.Models;
using WebApiITCrona.Infrastructure.Validators;
using Xunit;

namespace UnitTests.Validators;

/// <summary>
/// Тест валидации IP адреса
/// </summary>
public class IpRequestValidatorTest : ValidatorTestBase
{
    private readonly IpRequestValidator _validator = new IpRequestValidator();

    [Fact(DisplayName = "IP адрес валиден.")]
    public void IpRequestValidator_ValidIp_ValidatesSuccessfully()
    {
        // Arrange
        var ipRequest = new IpRequest { Ip = "192.168.0.1" };

        // Act
        var result = _validator.TestValidate(ipRequest);

        // Assert
        result.ShouldNotHaveValidationErrorFor(ip => ip.Ip);
    }

    [Fact(DisplayName = "IP адрес null. Бросает исключение.")]
    public void IpRequestValidator_NullIp_ThrowsValidationError()
    {
        // Arrange
        var ipRequest = new IpRequest { Ip = null };

        // Act
        var result = _validator.TestValidate(ipRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(ip => ip.Ip)
            .WithErrorMessage("IP-адрес не может быть пустым");
    }

    [Fact(DisplayName = "IP адрес пуст. Бросает исключение.")]
    public void IpRequestValidator_EmptyIp_ThrowsValidationError()
    {
        // Arrange
        var ipRequest = new IpRequest { Ip = "" };

        // Act
        var result = _validator.TestValidate(ipRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(ip => ip.Ip)
            .WithErrorMessage("IP-адрес не может быть пустым");
    }

    [Fact(DisplayName = "IP адрес не валиден. Бросает исключение.")]
    public void IpRequestValidator_InvalidIp_ThrowsValidationError()
    {
        // Arrange
        var ipRequest = new IpRequest { Ip = "invalid_ip" };

        // Act
        var result = _validator.TestValidate(ipRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(ip => ip.Ip)
            .WithErrorMessage("Некорректный формат IP-адреса");
    }
}