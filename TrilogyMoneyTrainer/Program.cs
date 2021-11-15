using TrilogyMoneyTrainer;

var process = MemoryHelper.OpenProcess(ProcessOpenAccess.All, "SanAndreas");

while (true)
{
    Console.Write("Desired money: ");
    var input = Console.ReadLine();
    if (int.TryParse(input, out int money))
    {
        byte[] data = BitConverter.GetBytes(money);
        process.Write(Offsets.Money, data);
        process.Write(Offsets.MoneyDisplay, data);
    }
}
