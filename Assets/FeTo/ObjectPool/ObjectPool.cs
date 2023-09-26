using FeTo.Exceptions;
using System.Collections.Generic;
using UnityEngine;

namespace FeTo.ObjectPool
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/ObjectPool#object-pool")]
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField, Tooltip("Throw exception when calling GetNext of an empty pool")]
        private bool ThrowErrorOnEmpty = true;

        [SerializeField]
        private int poolSize;

        [SerializeField]
        private PoolableObject prefab;

        [SerializeField]
        private List<PoolableObject> pool;

        private void Awake()
        {
            pool = new List<PoolableObject>();

            for (int i = 0; i < poolSize; i++)
            {
                CreateElement();
            }
        }

        private PoolableObject CreateElement()
        {
            PoolableObject element = Instantiate(prefab);
            element.SetPool(this);
            element.gameObject.SetActive(false);
            // pool.Add(element); // poolableObjects are added ondisable
            return element;
        }

        public void AddToPool(PoolableObject element)
        {
            pool.Add(element);
        }

        public PoolableObject GetNext()
        {
#if UNITY_EDITOR
            CheckEmptyPoolException();
#endif
            CheckEmptyPool();

            PoolableObject element = pool[0];
            pool.RemoveAt(0);
            return element;
        }

        private void CheckEmptyPoolException()
        {
            if (pool.Count == 0 && ThrowErrorOnEmpty)
            {
                throw new FeToException("Calling GetNext on empty Pool");
            }
        }

        private void CheckEmptyPool()
        {
            if (pool.Count == 0)
            {
                CreateElement();
            }
        }
    }
}