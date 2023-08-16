# Scriptable Variables 

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

## Make your own types

If you find yourself in need of a greater range of types for ScriptableVariables, you can always define your own types:

```C#
[CreateAssetMenu(fileName = "XXVariable", menuName = "MenuName")]
public class XXVariable : ScriptableVariable<XX>
{
    public override void ApplyChange(XX amount) { /* Implement */ }
    public override void ApplyChange(ScriptableVariable<XX> amount) { /* Implement */ }
}
```

## Data Persistance

It is known that the editor and build versions work differently with scriptable objects.

On the Editor all changes at runtime are saved on the scriptable object and persist through runs.

Once playing the Build, changes are saved on the memory copy of the scriptable object, meaning that when removed from memory (switching to a scene without a reference to the scriptable object or exiting the game) its values will be reset to the ones it had on the build.

In order to allow for a _similar_ behaviour in editor and build versions, Scriptable variables have been provided with (editor only) attribues

* bool resetValue
* T fixedValue (T of specific scriptable variable type)

If reset value is set to true (default) every time the play button is pressed, the scriptable variable value will be set to the fixedValue (ignoring the value it got in it's last run).  
Keep in mind that the values are "reset" on play, so if you build after playing, the values won't be updated (just play press and stop)

All in all, if you are looking for persistent data, using an external tool to do so is advised.