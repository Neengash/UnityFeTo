using UnityEditor;

[CustomEditor(typeof(FooTypeObject)), CanEditMultipleObjects]
public class FooTypeObjectEditor : Editor
{
    private Editor editorInstance;

    private void OnEnable() => editorInstance = null;

    public override void OnInspectorGUI()
    {
        // The inspected target component
        FooTypeObject fooTypeObject = (FooTypeObject)target;

        EditorGUILayout.LabelField("S.O. Data", EditorStyles.boldLabel);
        editorInstance = CreateEditor(fooTypeObject.fooType);
        // Draw the scriptableObjects inspector
        if (editorInstance != null)
        {
            editorInstance.DrawDefaultInspector();
        }
        else
        {
            EditorGUILayout.LabelField("No data from scriptable object");
        }

        EditorGUILayout.LabelField("Object Data", EditorStyles.boldLabel);
        // Show the variables from the MonoBehaviour
        base.OnInspectorGUI();
    }
}
