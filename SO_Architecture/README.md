# Scriptable Object Architecture

This module is based on the one project shared by Ryan Hipple, presented at Unite 2017.  
https://github.com/roboryantron/Unite2017

You can find the basic classes needed to build your game using the scriptable object architecture.  
Allowing for a decoupled, singleton free environment.

_Keep in mind that in order to use the following classes in your scripts you should import FeTo.SOArchitecture_

```c#
using FeTo.SOArchitecture;
```

## Scriptable Variables and References

Those two utilities ScriptableVariable and ScriptableReferenes, cover float, string and bool types. They can be used to share information of given types through multiple scripts without any need of hard coupling.

### Variables

Those are scriptable objects which content is just a float, string or bool value.  
They should be used when you want to change the value of the variable.

> Create > FeTo > SO_Architecture > FloatVariable  
> Create > FeTo > SO_Architecture > StringVariable
> Create > FeTo > SO_Architecture > BoolVariable

On the component you want to use the data you will need a reference to a FloatVariable, StringVariable or BoolVariable and then reference the given scriptable object through the inspector.

``` c#
[SerializedField] FloatVariable floatExample;
[SerializedField] StringVariable stringExample;
[SerializedField] BoolVariable boolExample;
```

To access or change data of a StringVariable or BoolVariable you have to access it's parameter "Value".

``` c#
stringExample.Value = "foo";
boolExample.Value = true;
```

To change or set the values of the FloatVariables it is advised to use the methods provided to do so:

``` c# 
public void SetValue(float value);
public void SetValue(FloatVariable value);
public void ApplyChange(float amount);
public void ApplyChange(FloatVariable amount);
```

Keep in mind that those scripts that modify the value of a FloatVariable or StringVariable should set it's initial value every time the game is played (in the editor), because otherwise the scriptable object will preserve the data from previous runs.

### References

You can also find FloatReference, StringReference and BoolReference.  
Those classes are meant to be used by those scripts that only want con read the data but not change it.  
They allow the user to link either a [*]Variable or a constant value, the last one being usefull for those places where there's no need take the data into an scriptable object for other components to use.

They can be used in code as if they were variables of the referenced type

``` c#
[SerializedField] FloatReference floatExample;
[SerializedField] StringReference stringExample;
[SerializedField] BoolReference boolReference;

float num = floatExample + 5f;
string text = stringExample + "some text";
if (boolReference) {}
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
