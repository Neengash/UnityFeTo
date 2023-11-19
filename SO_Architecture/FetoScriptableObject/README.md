# FeToScriptableObject

FeToScriptableObject is an abstract class that extends ScriptableObject.  
It's main purpose is to allow reseting the scriptableObjects atributes to their starting values once the play mode ends.  

IMPORTANT: It only works in editor mode.  
On the final build, FeToScriptableObjects work exactly the same way as scriptableObjects.

``` c#
[CreateAssetMenu]
public class MyCustomScriptableObjct : FeToScriptableObject
{
    // SCRIPTABLE OBJECT
}
```

For the FeToScriptableObjects to reset it's vales after exiting play mode, make sure _resetValue_ is set to true (default value).  
Otherwise they will work like any other scriptable object would.


![ResetValue Image](/Assets/FeTo/SO_Architecture/FetoScriptableObject/Media/ResetValue_Inspector.png)