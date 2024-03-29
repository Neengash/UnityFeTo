# Scriptable Object Architecture

This module is based on the one project shared by Ryan Hipple, presented at Unite 2017.  
https://github.com/roboryantron/Unite2017

You can find the basic classes needed to build your game using the scriptable object architecture.  
Allowing for a decoupled, singleton free environment.

_Keep in mind that in order to use the following classes in your scripts you should import FeTo.SOArchitecture_

```c#
using FeTo.SOArchitecture;
```

## [FeToScriptableObjects](/Assets/FeTo/SO_Architecture/FetoScriptableObject/)

Extension of the ScriptableObject class to allow - only on editor mode - to revert SO values to their starting value once the play mode ends.

## Scriptable [Variables](/Assets/FeTo/SO_Architecture/ScriptableVariables) and [References](/Assets/FeTo/SO_Architecture/ScriptableReferences)

Those two utilities: ScriptableVariable and ScriptableReferenes, cover int, float, string and bool types.  
They can be used to share information of given types through multiple scripts without any need of hard coupling.

## [Runtime Sets](/Assets/FeTo/SO_Architecture/RuntimeSet)

Sets are a way to organize data and make it easily accessible at runtime.  
RuntimeSets is an abstract class that should be inherited.

## [GameEvents](/Assets/FeTo/SO_Architecture/GameEvents)

UnityEvents are powerfull, but require coupling. That's why we add the middle layer the GameEvent.

---
---
---

_The following topics are informative only, they don't contain basic classes to extend or an already build functionality_

## [Enums](/Assets/FeTo/SO_Architecture/EnumScriptableObject/)

A new way to think about enums. 
Extend their basic behavior with scriptable objects.

## [The strategy Pattern](/Assets/FeTo/SO_Architecture/StrategyPattern/)

By using an abstract Scriptable object, and implementing multiple versions of it.  
We can easily set up an strategy pattern that get's managed in the editor.

## [Flyweight Pattern](/Assets/FeTo/SO_Architecture/FlyweightPattern/)

By moving common config data to scriptable objects we reduce the weight of monobehaviours.  
This can be achieved through the use of scriptable objects.