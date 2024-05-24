using FeTo.SOArchitecture;
using System.Collections.Generic;
using UnityEngine;

namespace FeTo.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        [SerializeField] SavingSystem savingSystem;
        [SerializeField] GameEvent saveFinishedEvent;
        [SerializeField] GameEvent loadFinishedEvent;

        public static List<SaveableEntity> SaveableEntities = new();

        private const string _defaultSaveFile = "save";

        private void Start() => savingSystem.Load(_defaultSaveFile);

        public void Save() {
            savingSystem.Save(_defaultSaveFile);
            if(saveFinishedEvent)
            {
                saveFinishedEvent.Raise();
            }
        }

        public void Load()
        {
            savingSystem.Load(_defaultSaveFile);
            if (loadFinishedEvent)
            {
                loadFinishedEvent.Raise();
            }
        }

        public void DeleteSave() => savingSystem.DeleteSaveFile(_defaultSaveFile);
    }
}