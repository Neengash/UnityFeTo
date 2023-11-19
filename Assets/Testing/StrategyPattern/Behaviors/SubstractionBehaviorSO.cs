using UnityEngine;

[CreateAssetMenu(fileName = "SubstractionBheavior", menuName = "EnemyBehavior/SubstractionBehavior")]
public class SubstractionBehaviorSO : EnemyBehaviorSO
{
    public override int Operate(int a, int b) => a - b;
}
