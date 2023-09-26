using FeTo.SOArchitecture;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

public class IntTesting : MonoBehaviour
{
    public IntReference intReference;
    public IntVariable intVariable;

    void Start()
    {
        Logger.Info($"intReference = {intReference}");
        Logger.Info($"intVariable = {intVariable.GetValue()}");
    }

    public void IntEventRaised(int i)
    {
        intVariable.ApplyChange(i);
        Logger.Info($"intVariable = {intVariable.GetValue()}");
    }
}
