# Scriptable References

The ScriptableReference class is NOT a scriptableObject.

Those classes are meant to be used by those scripts that only want to **read** data but not change it.  
They allow the user to link either a ScriptableVariable or a constant value, the last one being usefull for those places where there's no need take the data into an scriptable object for other components to use.

They can be used in code as if they were variables of the referenced type

``` c#
[SerializedField] FloatReference floatReference;
[SerializedField] StringReference stringReference;
[SerializedField] BoolReference boolReference;
[SerializedField] IntReference intReference;

float num = floatReference + 5f;
string text = $"{stringReference} some text";
if (boolReference) {}
int anotherNum = intReferece * 2;
```

### Make your own types

If you find yourself in need of a greater range of types for ScriptableVariables and References, you can always define your own types:

```C#
[Serializable]
public class XXReference : ScriptableReference<XX> { }
```