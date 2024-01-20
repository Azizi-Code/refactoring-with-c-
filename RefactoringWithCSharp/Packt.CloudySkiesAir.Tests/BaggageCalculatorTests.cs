using Xunit;

namespace Packt.CloudySkiesAir.Tests;

public class BaggageCalculatorTests
{
    [Fact]
    public void PriceWithNoBagsIsCorrect()
    {
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 0;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate);

        Assert.Equal(0, actualPrice);
    }

    [Fact]
    public void PriceWithTwoPassengersAndThreeCheckedIsCorrect()
    {
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate);

        Assert.Equal(190M, actualPrice);
    }

    [Fact]
    public void PriceWithCarryOnBagIsCorrect()
    {
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate);

        Assert.Equal(30M, actualPrice);
    }

    [Fact]
    public void PriceWithTwoCheckedIsCorrect()
    {
        BaggageCalculator calculator = new();
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate);

        Assert.Equal(120M, actualPrice);
    }

    [Fact]
    public void HolidayPriceIsCorrect()
    {
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 12, 19);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate);

        Assert.Equal(209M, actualPrice);
    }
}