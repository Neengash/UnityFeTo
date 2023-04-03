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

Those two utilities: ScriptableVariable and ScriptableReferenes, cover int, float, string and bool types.  
They can be used to share information of given types through multiple scripts without any need of hard coupling.

### Variables

Those are scriptable objects which content is just a value (of types int, float, string or bool).  
They should be used when you want to **change** the value of the variable.

> Create > FeTo > SO_Architecture > FloatVariable  
> Create > FeTo > SO_Architecture > StringVariable  
> Create > FeTo > SO_Architecture > BoolVariable  
> Create > FeTo > SO_Architecture > IntVariable  

On the component you want to use the data you will need a reference to an IntVariable, FloatVariable, StringVariable or BoolVariable and then reference the given scriptable object through the inspector.  
Warning: Due to some limitations, on the inspector you will see `ScriptableVariable'1` as the type of the object, but it will only accept the one specified in the code.

``` c#
[SerializedField] FloatVariable floatExample;
[SerializedField] StringVariable stringExample;
[SerializedField] BoolVariable boolExample;
[SerializedField] IntVariable intVariable;
```

ScriptableVariables should be worked with by using its methods:

```C#
public T GetValue();
public void SetValue(T value);
public void SetValue(ScriptableVariable<T> value);
public void ApplyChange(T amount);
public void ApplyChange(ScriptableVariable<T> amount);
```

Keep in mind some ScriptableVariable types (such as string or bool) might not implement the ApplyChange method.

Keep in mind that scripts that modify the value of scriptableVariables should set it's initial value every time the game is played (in the editor), because **on the editor** the scriptable object will preserve the data from previous runs.

### References

You can also find the ScriptableReference class, those are NOT scriptableObjects.  
Those classes are meant to be used by those scripts that only want to **read** the data but not change it.  
They allow the user to link either a ScriptableVariable or a constant value, the last one being usefull for those places where there's no need take the data into an scriptable object for other components to use.

They can be used in code as if they were variables of the referenced type

``` c#
[SerializedField] FloatReference floatExample;
[SerializedField] StringReference stringExample;
[SerializedField] BoolReference boolReference;
[SerializedField] IntReference intReference;

float num = floatExample + 5f;
string text = stringExample + "some text";
if (boolReference) {}
int anotherNum = intReferece * 2;
```

### Make your own types

If you find yourself in need of a greater range of types for ScriptableVariables and References, you can always define your own types:

```C#
[Serializable]
public class XXReference : ScriptableReference<XX> { }
```

```C#
[CreateAssetMenu(fileName = "XXVariable", menuName = "MenuName")]
public class XXVariable : ScriptableVariable<XX>
{
    public override void ApplyChange(XX amount) { /* Implement */ }
    public override void ApplyChange(ScriptableVariable<XX> amount) { /* Implement */ }
}
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
