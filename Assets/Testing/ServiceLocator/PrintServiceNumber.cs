using FeTo.ServiceLocator;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

public class PrintServiceNumber : MonoBehaviour
{
    private ITestService _testService;
    private ITestService TestService
    {
        get => _testService ??= ServiceLocator.Instance.GetService<ITestService>();
    }

    public void Print()
    {
        Logger.Info($"{TestService.GetRandomValue()}");
    }
}
