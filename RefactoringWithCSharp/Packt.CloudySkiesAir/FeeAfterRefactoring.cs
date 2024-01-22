namespace Packt.CloudySkiesAir;

public class FeeAfterRefactoring
{
    public decimal Total { get; set; }

    public void ChargeFee(decimal fee, string chargeName)
    {
        Console.WriteLine($"{chargeName}: {fee}");
        Total += fee;
    }
}