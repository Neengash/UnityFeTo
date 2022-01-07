using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] int poolSize;
    [SerializeField] PoolableObject prefab;
    [SerializeField]
    List<PoolableObject> pool;

    void Start()
    {
        pool = new List<PoolableObject>();

        for (int i = 0; i < poolSize; i++)
        {
            PoolableObject element = Instantiate(prefab);
            element.setPool(this);
            element.gameObject.SetActive(false);
            // pool.Add(element); // poolableObjects are added ondisable
        }
    }

    public void addToPool(PoolableObject element) {
        pool.Add(element);
    }

    public PoolableObject getNext()
    {
        if (pool.Count > 0)
        {
            PoolableObject element = pool[0];
            pool.RemoveAt(0);
            return element;
        }
        return null;
    }
}