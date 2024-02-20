using Newtonsoft.Json.Linq;
using UnityEngine;
using FeTo.Saving;

public class Position : MonoBehaviour, ISaveable
{
    public JToken CaptureAsJToken()
    {
        return transform.position.ToToken();
    }

    public void RestoreFromJToken(JToken state)
    {
        transform.position = state.ToVector3();
    }
}
