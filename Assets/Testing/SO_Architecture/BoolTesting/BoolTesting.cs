using FeTo.SOArchitecture;
using UnityEngine;
using Logger = FeTo.Logging.Logger;

public class BoolTesting : MonoBehaviour
{
    public BoolReference boolReference;

    public BoolVariable boolVariable;

    private void Start()
    {
        Logger.Info($"boolReference = {boolReference}");
    }

    public void BoolEventRaised(bool value)
    {
        boolVariable.SetValue(value);
        Logger.Info($"boolVariable = {boolVariable.GetValue()}");
    }
}
