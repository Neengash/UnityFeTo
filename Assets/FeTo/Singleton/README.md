# Singleton

Make any other component a singleton by extending this class.

Example:

``` c#
public class MyClass : Singleton<MyClass> { }
```

Then the class methods and properties can be called as easily as:

``` c#
MyClass.Instance.MethodCall()
```

# Persistent singleton

Make any other component a singleton that persists between scenes by extending this class. 

``` C#
public class MyClass : PersistentSingleton<MyClass> { }
```

Then the class methods and properties can be called as easily as:

``` c#
MyClass.Instance.MethodCall()
```

# !! Warning !! 

In either use of the previous singleton classes, for instance calls inside Monobehaviour methods such as OnDisable or OnDestroy, to prevent null references (Singleton could have already been destroyed) it is recommended to use the null conditional operator:

``` c#
MyClass.Instance?.MethodCall()
```