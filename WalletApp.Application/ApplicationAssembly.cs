using System.Reflection;

namespace WalletApp.Application;

public sealed class ApplicationAssembly
{
    public static Assembly GetAssembly()
    {
        return typeof(ApplicationAssembly).Assembly;
    }
}
