using Xunit;

namespace Packt.CloudySkiesAir.Tests;

public class BaggageCalculatorAfterRefactoringTests
{
    [Fact]
    public void PriceWithNoBagsIsCorrect()
    {
        BaggageCalculatorAfterRefactoring calculator = new();
        int numChecked = 0;
        int numCarryOn = 0;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers,
            travelDate.Month >= 11 || travelDate.Month <= 2);

        Assert.Equal(0, actualPrice);
    }

    [Fact]
    public void PriceWithTwoPassengersAndThreeCheckedIsCorrect()
    {
        BaggageCalculatorAfterRefactoring calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers,
            travelDate.Month >= 11 || travelDate.Month <= 2);

        Assert.Equal(190M, actualPrice);
    }

    [Fact]
    public void PriceWithCarryOnBagIsCorrect()
    {
        BaggageCalculatorAfterRefactoring calculator = new();
        int numChecked = 0;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers,
            travelDate.Month >= 11 || travelDate.Month <= 2);

        Assert.Equal(30M, actualPrice);
    }

    [Fact]
    public void PriceWithTwoCheckedIsCorrect()
    {
        BaggageCalculatorAfterRefactoring calculator = new();
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers,
            travelDate.Month >= 11 || travelDate.Month <= 2);

        Assert.Equal(120M, actualPrice);
    }

    [Fact]
    public void HolidayPriceIsCorrect()
    {
        BaggageCalculatorAfterRefactoring calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 12, 19);

        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers,
            travelDate.Month >= 11 || travelDate.Month <= 2);

        Assert.Equal(209M, actualPrice);
    }
}