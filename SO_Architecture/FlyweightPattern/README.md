# Flyweight Pattern

Using Scriptable Objects as contaners for configuration data allows components (monobehaviours) to share this configuration data, making them a little lighter.  

But by default this generates the difficulty of having the data separated into two parts, (common config data on the S.O. and individual data on the Monobehaviour) forcing the designer to either use multiple inspector windows or jump between them to see and edit all data.

To solve this difficulty, here's a basic example of an editor file that makes the inspector of the component also show the referenced scriptable object data.

The scriptable object
```c#
using UnityEngine;

[CreateAssetMenu()]
public class MyScriptableObject : FeToScriptableObject
{
    public int intAttribute;
    public string stringAttribute;
}

```
The component
```c#
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    [SerializeField] public MyScriptableObject myScriptableObject;
}
```
The Editor (remember to place it inside a folder named editor)
```c#
using UnityEditor;

[CustomEditor(typeof(MyMonoBehaviour)), CanEditMultipleObjects]
public class MyMonoBehaviourEditor : Editor
{
    private Editor editorInstance;

    // Reset the editor instance
    private void OnEnable() => editorInstance = null;

    public override void OnInspectorGUI()
    {
        // The inspected target component
        MyMonoBehaviour myMonoBehaviour = (MyMonoBehaviour)target;

        // Draw the scriptableObjects inspector
        EditorGUILayout.LabelField("S.O. Data", EditorStyles.boldLabel);
        editorInstance = CreateEditor(myMonoBehaviour.myScriptableObject);
        if (editorInstance != null)
        {
            editorInstance.DrawDefaultInspector();
        }
        else
        {
            EditorGUILayout.LabelField("No data from scriptable object");
        }

        // Show the variables from the MonoBehaviour
        EditorGUILayout.LabelField("Component Data", EditorStyles.boldLabel);
        base.OnInspectorGUI();
    }
}
```