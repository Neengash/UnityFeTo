using FeTo.ServiceLocator;
using UnityEngine;

public class PrintServiceNumber : MonoBehaviour
{
    private ITestService _testService;
    private ITestService TestService
    {
        get => _testService ??= ServiceLocator.Instance.GetService<ITestService>();
    }

    public void Print()
    {
        Debug.Log(TestService.GetRandomValue());
    }
}
