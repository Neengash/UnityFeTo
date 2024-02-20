using FeTo.Saving;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Health : MonoBehaviour, ISaveable
{
    [SerializeField] float health = 100f;

    public JToken CaptureAsJToken()
    {
        return JToken.FromObject(health);
    }

    public void RestoreFromJToken(JToken state)
    {
        health = state.ToObject<float>();
    }
}
