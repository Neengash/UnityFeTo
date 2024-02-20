using System.Collections.Generic;
using UnityEngine;

namespace FeTo.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        [SerializeField] SavingSystem savingSystem;

        public static List<SaveableEntity> SaveableEntities = new();

        private const string _defaultSaveFile = "save";

        private void Start() => savingSystem.Load(_defaultSaveFile);

        public void Save() {
            savingSystem.Save(_defaultSaveFile);
        }

        public void Load()
        {
            savingSystem.Load(_defaultSaveFile);
        }

        public void DeleteSave() => savingSystem.DeleteSaveFile(_defaultSaveFile);
    }
}