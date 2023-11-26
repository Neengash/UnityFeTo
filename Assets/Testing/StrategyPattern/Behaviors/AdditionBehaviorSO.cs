using UnityEngine;

[CreateAssetMenu(fileName = "AdditionBehavior", menuName = "EnemyBehavior/AdditionBehavior")]
public class AdditionBehaviorSO : EnemyBehaviorSO
{
    public override int Operate(int a, int b)
    {
        return a + b;
    }
}

