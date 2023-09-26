using UnityEngine;
using Logger = FeTo.Logging.Logger;

public class GameEventTest : MonoBehaviour
{
    public void GameEventRaised()
    {
        Logger.Info("Game Event Raised");
    }
}
