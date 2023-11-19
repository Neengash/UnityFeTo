# Enum Scriptable Objects

There is no extensible code for this point, instead that is a concept you might want to use in your games.

Using ScriptableObjects as enums allows you to:  
* Choose different values for the enum from the editor (drag and dropping scriptable objects)
* Add extra logic or data to your "enum" types.
* Avoid errors when reordering or changing enum values

```c#
[CreateAssetMenu()]
public class MySOEnum : FeToScriptableObject
{
    // Attributes that every value of the enum will have
}
```

Now you simply have to create instances of that Scriptable Object and you have your customizable Enum.