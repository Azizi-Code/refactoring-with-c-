namespace Packt.CloudySkiesAir;

public class BaggageCalculatorAfterRefactoring
{
    private const decimal CarryOnFee = 30M;
    private const decimal FirstBagFee = 40M;
    private const decimal ExtraBagFee = 50M;
    public decimal HolidayFeePercent { get; set; } = 0.1M;

    public decimal CalculatePrice(int bags, int carryOn, int passengers, bool isHoliday)
    {
        decimal total = 0;

        if (carryOn > 0)
        {
            var fee = carryOn * CarryOnFee;
            Console.WriteLine($"Carry-on: {fee}");
            total += fee;
        }

        if (bags > 0)
        {
            var bagFee = ApplyCheckedBagFee(bags, passengers);
            Console.WriteLine($"Checked: {bagFee}");
            total += bagFee;
        }

        if (isHoliday)
        {
            var holidayFee = total * HolidayFeePercent;
            Console.WriteLine("Holiday Fee: " + holidayFee);

            total += holidayFee;
        }

        return total;
    }

    private static decimal ApplyCheckedBagFee(int bags, int passengers)
    {
        if (bags <= passengers)
        {
            var firstBagFee = bags * FirstBagFee;
            return firstBagFee;
        }
        else
        {
            var firstBagFee = passengers * FirstBagFee;
            var extraBagFee = (bags - passengers) * ExtraBagFee;
            decimal checkedFee = firstBagFee + extraBagFee;

            return checkedFee;
        }
    }
}