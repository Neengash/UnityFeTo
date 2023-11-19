# Enum Scriptable Objects

There is no extensible code for this point, instead that is a concept you might want to use in your games.

Using ScriptableObjects as enums allows you to:  
* Choose different values for the enum from the editor (drag and dropping scriptable objects)
* Add extra logic or data to your "enum" types.
* Avoid errors when reordering or changing enum values

```c#
public abstract class SO_Enum : FeToScriptableObject {}
```
```c#
[CreateAssetMenu]
public class FirstValue : SO_Enum {}
```
```c#
[CreateAssestMenu]
public class SecondValue : SO_Enum {}
```
```c#
[CreateAssestMenu]
public class ThirdValue : SO_Enum {}
```
