# Singleton

Make any other component a singleton by extending this class.

Example:

``` c#
public class MyClass : Singleton<MyClass> { }
```

# Persistent singleton

Make any other component a singleton that persists between scenes by extending this class. 

``` C#
public class MyClass : PersistentSingleton<MyClass> { }
```