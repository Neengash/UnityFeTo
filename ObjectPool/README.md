# Object Pool

This tools contains two elements "ObjectPool" class and "PoolableObject" class.

## Poolable object

Gameobjects that are going to be managed by the object pool should extend this class.

Example:

``` c#
public class MyPooledObject : PoolableObject { }
```

## Object Pool

Add this class to any gameObject to generate the objectPool. You will need to specify the size of the pool as well as the prefab to pool (it needs to extend the Poolable object class).

To get an instance of the pool you simple have to call the GetNext() method of the ObjectPool reference. Once done working with the instance, disable it and it will autimatically return to the objectPool, available for future calls to action.

``` c#
MyPooledObject myPooledObject = (MyPooledObject)MyObjectPool.getNext();
```