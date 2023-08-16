using UnityEngine;

public class TestService : ITestService
{
    public int GetRandomValue()
        => Random.Range(0, 10);
}
