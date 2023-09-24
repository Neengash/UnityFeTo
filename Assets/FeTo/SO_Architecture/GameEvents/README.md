## Scriptable Object - GameEvents

UnityEvents are powerfull, but require coupling. That's why we add the middle layer the GameEvent.

> Create > FeTo > SO_Architecture > GameEvent  

And some extra GameEvent types which allow to pass data along with the event raise

> Create > FeTo > SO_Architecture > BoolGameEvent  
> Create > FeTo > SO_Architecture > IntGameEvent  
> Create > FeTo > SO_Architecture > FloatGameEvent  
> Create > FeTo > SO_Architecture > StringGameEvent  

When you want the event to be raised, your code should call the GameEvent.  
This applies both to code and to UI elements (for instance: onClick).

``` c#
public class ExampleClass : MonoBehaviour
{
    public GameEvent ExampleEvent;
    public IntGameEvent intGameEvent;

    private void Start() => exampleEvent.Raise();
    public void SendInt(int value) => intGameEvent.Raise(value);
}
```

To capture GameEvents, you have the `GameEventListener` (or `xxGameEventListener` for the typed ones) class, you can add as a component to any GameObject, and then specify in the inspector which methods (from other components of the same game object) should be called.

### Using GameEvents on UI

In case you want to use GameEvents in UI (for example as an action for a button) it's prefered to use the method `UIRaise`

### Raisable through Inspector

GameEvent Scriptable Objects can be raised manually during gameplay since it's inspector data has been modified to show a button with such functionality.  
This allow for an easier testing in gameDevelopment

### Traceability

To ease traceability of events through the game, in editor mode only, every time an event is both raised and catched, a info level messsage is logged on console.  
Notifying who raised the method and who catched the method.

For this functionality, the raise method has an extra parameter called `callerName`.  

You can leave that parameter blank and it will automatically be completed with the name of the gameobject that performed the Raise.  
Or you can overload the name, setting some custome name if that helps your debugging.

### Make your own types

If you find yourself in need of a gameEvent that passes some data of a type not covered in FeTo you can always create your own GameEvent

```C#
[System.Serializable]
public class XXEvent : UnityEvent<XX> { }
[CreateAssetMenu(fileName = "XXGameEvent", menuName = "MenuName")]
public class XXGameEvent : GameEvent<XX, XXEvent> { }
```

## GameEventListeners

For GameEvents to be useful you need some object to be listnening to it.
That's where gameEventListeners come into play.

Every object that you want to be listening to a specific gameEvent should have a GameEventListener.

### OnEnable GameEventListener

FeTo comes with a handfull of gameEventListeners (one for each type of GameEvent mentioned above).
They all implement the *OnEnable* logic, meaning, the will listen to the event as long as they are enabled.

Those Game Event listeners (components) are:
```c#
OnEnableGameEventListener
OnEnableBoolGameEventListener
OnEnableIntGameEventListener
OnEnableFloatGameEventListener
OnEnableStringGameEventListener
```

### Custom Behavior GameEventListeners

It could happen that you don't want to listen to the event when the listener is enabled, but when the player enters some trigger, or even make it a part of the game logic.   
For such cases you will find the abstract GameEventListener clases you will have to extend, indicating when they should start and stop listening to the event. (Take any `OnEnableGameEventListener` as a example).  

To Register and unregister (start and stop listening) you just need to call those functions.
```c#
Event.RegisterListener(this);
Event.UnregisterListener(this);
```

### Make your own types

The same way you can create new GameEvents, you will need new GameEventListeners to listlen to them.
*Keep in mind that since they depend on one another, you should make both for every type of gameElement you want to create*

```C#
public class XXGameEventListener : GameEventListener<XX, XXEvent> { }
```

You could either leave that class empty, and then create a new Behavior class for the new XXGameEventListener, or just add behavior and gameEventListener type in the same class.  
(Take at `TypedGameEventListeners` and `OnEnableGameEventListeners`)