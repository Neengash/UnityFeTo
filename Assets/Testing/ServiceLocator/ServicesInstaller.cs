using FeTo.ServiceLocator;
using UnityEngine;

public class ServicesInstaller : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Instance.RegisterService<ITestService>(new TestService());
    }
}
