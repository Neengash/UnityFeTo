using FeTo.SOArchitecture;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

public class FloatTesting : MonoBehaviour
{
    public FloatReference floatReference;
    public FloatVariable floatVariable;

    private void Start()
    {
        Logger.Info($"floatReference = {floatReference}");
        Logger.Info($"floatVariable = {floatVariable.GetValue()}");
    }

    public void FloatEventRaised(float i)
    {
        floatVariable.ApplyChange(i);
        Logger.Info($"floatVariable = {floatVariable.GetValue()}");
    }
}
