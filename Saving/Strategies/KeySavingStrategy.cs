using FeTo.Saving;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FeTo.Saving
{
    public abstract class KeySavingStrategy : SavingStrategy
    {
#if UNITY_EDITOR
        public abstract void GenerateKey();
#endif
    }
}

