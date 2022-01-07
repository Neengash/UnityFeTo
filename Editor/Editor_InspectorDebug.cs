using System;
using System.Reflection;
using UnityEditor;

public class Editor_InspectorDebug
{
    [MenuItem("Tools/Toggle Inspector Mode &d")] // Shortcut Alt + d
    static void ToggleInspectorDebug()
    {
        EditorWindow targetInspector = EditorWindow.mouseOverWindow; // "EditorWindow.focusedWindow" can be used instead
        if (targetInspector != null  && targetInspector.GetType().Name == "InspectorWindow")
        {
            Type type = Assembly.GetAssembly(typeof(UnityEditor.Editor)).GetType("UnityEditor.InspectorWindow");    //Get the type of the inspector window to find out the variable/method from
            FieldInfo field = type.GetField("m_InspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);    //get the field we want to read, for the type (not our instance)
            
            InspectorMode mode = (InspectorMode)field.GetValue(targetInspector);                                    //read the value for our target inspector
            mode = (mode == InspectorMode.Normal ? InspectorMode.Debug : InspectorMode.Normal);                    //toggle the value
            
            MethodInfo method = type.GetMethod("SetMode", BindingFlags.NonPublic | BindingFlags.Instance);          //Find the method to change the mode for the type
            method.Invoke(targetInspector, new object[] {mode});                                                    //Call the function on our targetInspector, with the new mode as an object[]
        
            targetInspector.Repaint();       //refresh inspector
        }
    }
}