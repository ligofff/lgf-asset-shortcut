using System.Reflection;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssetShortcut))]
public class AssetShortcutEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AssetShortcut assetShortcut = (AssetShortcut)target; 

        var objField = typeof(AssetShortcut).GetField("obj", BindingFlags.NonPublic | BindingFlags.Instance); 

        Object obj = EditorGUILayout.ObjectField("Object", (Object)objField.GetValue(assetShortcut), typeof(Object), true);

        if (GUI.changed)
        {
            objField.SetValue(assetShortcut, obj);
            EditorUtility.SetDirty(assetShortcut);
        }

        EditorGUILayout.HelpBox("This is only a shortcut of asset placed in " + AssetDatabase.GetAssetPath(obj), MessageType.Warning); 

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        if (obj != null)
        {
            Editor objEditor = CreateEditor(obj);
            objEditor.OnInspectorGUI();
        }
    }
}