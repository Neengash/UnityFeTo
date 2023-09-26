using FeTo.SOArchitecture;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

public class StringTesting : MonoBehaviour
{
    public StringReference stringReference;
    public StringVariable stringVariable;

    void Start()
    {
        Logger.Info($"stringReference = {stringReference}");
        Logger.Info($"stringVariable = {stringVariable.GetValue()}");
    }

    public void StringEventRaised(string value)
    {
        stringVariable.SetValue(value);
        Logger.Info($"stringVariable = {stringVariable.GetValue()}");
    }
}
