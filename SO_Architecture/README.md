# Scriptable Object Architecture

This module is based on the one project shared by Ryan Hipple, presented at Unite 2017.  
https://github.com/roboryantron/Unite2017

You can find the basic classes needed to build your game using the scriptable object architecture.  
Allowing for a decoupled, singleton free environment.

## Scriptable Object - Variables

Those are scriptable objects which value is just a float or string value.  
Use them when you want some data to be available through multiple classes 

> Create > FeTo > SO_Architecture > FloatVariable  
> Create > FeTo > SO_Architecture > StringVariable

On the component you want to access the data you will need a reference to a FloatVariable or StringVariable and then reference the given scriptable object through the inspector

``` c#
[SerializedField] FloatVariable floatExample;
[SerializedField] StringVariable stringExample;
```

### Bonus: Float Reference

This is an intermediate layer for the float variable scriptable object which allows you to use either a constant value or a scriptable object. It's intention is to replace public (or serialized) float variables, so that through inspector a designer can decide whether a const value or scriptable object variable will be used.

``` c#
[SerializedField] FloatReference floatExample;
```

## Scriptable Object - Runtime Sets

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

## Scriptable Object - Events

UnityEvents are powerfull, but require coupling. That's why we add the middle layer the GameEvent.

> Create > FeTo > SO_Architecture > GameEvent  

When you want the event to be raised, your code should call the GameEvent.  
This applies both to code and to UI elements (for instance: onClick).

``` c#
public class ExampleClass : MonoBehaviour
{
    public UnityEvent ExampleEvent;

    private void Start() => ExampleEvent.Invoke();
}
```

To capture such events, you have the `GameEventListener` class, you can add as a component to any GameObject, and then specify in the inspector which methods (from other components of the same game object) should be called.

### Bonus : Raise through Inspector

GameEvent Scriptable Objects can be raised manually during gameplay since it's inspector data has been modified to show a button with such functionality.

## Warning: Persistance
Keep in mind that the editor and the build work differently with scriptable objects.

On the Editor all changes at runtime are saved on the scriptable object and persist through runs.

Once playing the Build, changes are saved on the memory copy of the scriptable object, meaning that when removed from memory (switching to a scene without a reference to the scriptable object or exiting the game) its values will be reset to the ones it had on the build.

If you want persistent data, using an external tool to do so is advised.
