# FeTo Saving

This module is based on the Medium article publisehd by Onur Kiris. 

- [Modular Save Load System for Unity - Part 1](https://medium.com/@onurkiris05/modular-save-load-system-for-unity-part-1-ad59a3d9754c) 
- [Modular Save Load System for Unity - Part 2](https://medium.com/@onurkiris05/modular-save-load-system-for-unity-part-2-24520b537bab)

You can find the basic classes needed to save, load and remove file data

## Saving components:
### [Saving System](/Assets/FeTo/Saving/SavingSystem.cs)
This script must be attached to GameObject in the Unity scene.
This script needs a reference to one strategy scriptable object and has the general logic in order to save, load and delete save file.
### [Strategies](/Assets/FeTo/Saving/Strategies)
The strategy is the way in wich data will be saved in the file. To create an scriptable object strategy:

`Right clic > Create > FeTo > Saving Strategies`

Available strategies are:
- [Json](/Assets/FeTo/Saving/Strategies/JsonStrategy.cs): just saved as plan text in json format
- [Json + XOR](/Assets/FeTo/Saving/Strategies/XorStrategy.cs): uses XOR encryption. _**It's needed to press the "Generate Key" button placed in editor when scriptable object strategy is selected.**_
- [Json + XOR + Base64](/Assets/FeTo/Saving/Strategies/XorTextStrategy.cs): use XOR encryption and Base64 encoding. _**It's needed to press the "Generate Key" button placed in editor when scriptable object strategy is selected.**_

![Generate key button image {caption=Button placed in strategy to generate new key}](/Assets/FeTo/Saving/Media/GenerateKeyButton.png)

If you prefer other ways to sotore the data in a file you can create new strategies inheriting from [SavingStrategy](/Assets/FeTo/Saving/Strategies/SavingStrategy.cs) or [KeySavingStrategy](/Assets/FeTo/Saving/Strategies/KeySavingStrategy.cs). If your strategy use a key to encrypt the data, ensure you also implement the [editor](/Assets/FeTo/Saving/Editor/XorStrategyEditor.cs) in order to generate the key 
### [Saving Wrapper](/Assets/FeTo/Saving/SavingWrapper.cs)
This file has the public functions to do the opetrations over the file and needs the file name, this file name can be provided in editor

The exposed functions are:

``` C#
public void Save()
public void Load()
public void DeleteSave()
```
### [Saveable Entity](/Assets/FeTo/Saving/SaveableEntity.cs)
This script must be added as component to any GameObject which has any data to save. 
### [ISaveable](/Assets/FeTo/Saving/ISaveable.cs)
Include this interface to any script with data to store an then implement both methods in order to save and load data.

``` c#
JToken CaptureAsJToken();
void RestoreFromJToken(JToken state);
```

Following implementation is an example of implementation for health value in a health manager which implements ISaveable interface.

``` c#
public JToken CaptureAsJToken()
{
    return JToken.FromObject(health);
}

public void RestoreFromJToken(JToken state)
{
    health = state.ToObject<float>();
}
```

## Extension methods
Since JToken does not accept Vector3, two extension methods have been implemented in order to save and load Vector3 elements.

``` c#
public static JToken ToToken(this Vector3 vector)
public static Vector3 ToVector3(this JToken state)
```

With this functions you can save and load Vector3, for example for a GameObject's position

``` c#
public JToken CaptureAsJToken()
{
    return transform.position.ToToken();
}

public void RestoreFromJToken(JToken state)
{
    transform.position = state.ToVector3();
}
```

If your game uses data not compatible with JToken, you can make your own extension methods as [Vector3ExtensionMethods](/Assets/FeTo/Saving/Vector3ExtensionMethods.cs)

## Sample scene
You can check a sample scene which uses this system to store a cube's position and health. This example also use [FeTo SO_Architecture](/Assets/FeTo/SO_Architecture)

All the code used in sample scene is placed [here](/Assets/SampleScenes/Saving/Code)