using UnityEngine;

namespace FeTo.ObjectPool
{
    public abstract class PoolableObject : MonoBehaviour
    {
        protected ObjectPool pool;

        public void SetPool(ObjectPool pool)
        {
            this.pool = pool;
        }

        protected virtual void OnDisable()
        {
            if (pool == null) { return; }
            pool.AddToPool(this);
        }
    }
}