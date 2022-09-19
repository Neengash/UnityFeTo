using UnityEngine;

[CreateAssetMenu(fileName = "TMPBlinkScriptable", menuName = "Scriptables/UnityFeTo/TMPBlinkScriptable", order = 1)]
public class TMPBlinkScriptable : ScriptableObject
{
    [Header("Time properties")]
    public float FadeInTime;
    public float FadeInStayTime;
    public float FadeOutTime;
    public float FadeOutStayTime;

    [Header("Other configuration")]
    public bool loop;
}
