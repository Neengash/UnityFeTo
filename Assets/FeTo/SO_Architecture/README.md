# Scriptable Object Architecture

This module is based on the one project shared by Ryan Hipple, presented at Unite 2017.  
https://github.com/roboryantron/Unite2017

You can find the basic classes needed to build your game using the scriptable object architecture.  
Allowing for a decoupled, singleton free environment.

_Keep in mind that in order to use the following classes in your scripts you should import FeTo.SOArchitecture_

```c#
using FeTo.SOArchitecture;
```

## Scriptable [Variables](/Assets/FeTo/SO_Architecture/ScriptableVariables) and [References](/Assets/FeTo/SO_Architecture/ScriptableReferences)

Those two utilities: ScriptableVariable and ScriptableReferenes, cover int, float, string and bool types.  
They can be used to share information of given types through multiple scripts without any need of hard coupling.

## [Runtime Sets](/Assets/FeTo/SO_Architecture/RuntimeSet)

Sets are a way to organize data and make it easily accessible at runtime.  
RuntimeSets is an abstract class that should be inherited.

## [GameEvents](/Assets/FeTo/SO_Architecture/GameEvents)

UnityEvents are powerfull, but require coupling. That's why we add the middle layer the GameEvent.
