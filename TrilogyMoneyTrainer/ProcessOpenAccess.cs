namespace TrilogyMoneyTrainer;

public enum ProcessOpenAccess
{
    Read = 0x0010,
    Write = 0x0020,
    Operation = 0x0008,

    All = Read | Write | Operation
}
