# Runtime Sets

Sets are a way to organize data and make it easily accessible at runtime.  
RuntimeSets is an abstract class that should be inherited.

``` c#
[CreateAssetMenu]
public class ExampleRuntimeSet : RuntimeSet<ExampleClass>
{}
```

This way, you only have to add objects you want to be tracked, for example on their onEnable.

``` c#
public class ExampleClass : MonoBehaviour
{
    public ExampleRuntimeSet runtimeSet;

    private void OnEnable() => runtimeSet.Add(this);
    private void OnDisable() => runtimeSet.Remove(this);
}
```