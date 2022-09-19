using UnityEngine;

[CreateAssetMenu(fileName = "TMPBlinkScriptable", menuName = "Scriptables/UnityFeTo/TMPBlinkScriptable", order = 1)]
public class TMPBlinkScriptable : ScriptableObject
{
    public float FadeInTime;
    public float FadeInStayTime;
    public float FadeOutTime;
    public float FadeOutStayTime;

    public bool loop;
}
