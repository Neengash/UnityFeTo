# Service Locator

Provides the basic tools to use the service Locator pattern.

The service locator class is implemented as a singleton, so it can be accessed through `ServiceLocator.Instance`

## How to use

### Installer

Create an _installer_ script that will look similar to this one (register whatever services you want to use)

```c#
using FeTo.ServiceLocator;
using UnityEngine;

public class ServicesInstaller : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Instance.RegisterService<ITestService>(new TestService());
    }
}
```

#### Bonus Tip

To prevent any unexpected exceptions related to trying to get a service prior to it's registration,  
it is advised to change the execution time of the ServicesInstaller.

`Edit > Project Settings > Script Execution Order > + > ServicesInstaller > -50`

### Usage

Now from any class you can get the registered services:

```c#
using FeTo.ServiceLocator;
using UnityEngine;

public class MyComponent : MonoBehaviour
{
    public void MyFunction()
    {
        ITestService testService = ServiceLocator.Instance.GetService<ITestService>();
        // Code Here
    }
}
```

#### Bonus Tip

For code that will use a service repeatedly, it is recommended to save a local reference to it, to avoid calling the service locator everysingle time.

```c#
public class MyComponent : MonoBehaviour
{
    private ITestService _testService;
    private ITestService TestService
    {
        get => _testService ??= ServiceLocator.Instance.GetService<ITestService>();
    }

    public void MyFunction()
    {
        TestService.TestMethod();
    }
}

```