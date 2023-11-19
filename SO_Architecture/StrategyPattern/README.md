# Strategy pattern through Scriptable objects

Scriptable Objects are a really good tool for implementing an strategy pattern.  
The only thing we need will be an abstract parent scriptable object, and all of the children classes will be our different strategies.

_No base class is provided for this pattern, since everything will need to be defined according to the specific needs_

_Keep in mind tat if the scriptable objects have private attributes, they will be shared amongst all instances, so consider them as singletons_
_If needed, you could create a copy of an scriptable to allow them to contain different attributes._

Here an example:

The parent class (equivalent to an interface)
```c#
public abstract class Operation : FeToScriptableObject 
{
    public abstract int Perform (int a, int b);
}
```
Its implementations
```c#
public class AdditionOperation : Operation
{
    public override int Perform (int a, int b) => a + b;
}
```

```c#
public class SubstractionOperation : Operation
{
    public override int Perform (int a, int b) => a - b;
}
```

To use it we simply define a reference to Operation:  
And from the inspector we will choose what operation we want to perform
```c#
public class MyComponent : Monobehavior
{
    [SerializeField] public int A, B, C;
    [SerializeField] public Operation operation;

    public void Start() {
        C = operation.Perform(A, B);
    }
}
```