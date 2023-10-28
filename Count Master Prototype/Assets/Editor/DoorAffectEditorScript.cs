using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;

[CustomEditor(typeof(Door))]
public class DoorAffectEditorScript : Editor
{

    SerializedProperty affectValue;
    private TMP_Text affectText;

    private void OnEnable()
    {
        affectValue = serializedObject.FindProperty("affectCount");
        affectText = findTMPComponent(target);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.IntSlider(affectValue, -100, 100);
        affectText.text = addPlusSignIfPositive(affectValue.intValue);
        EditorUtility.SetDirty(affectText);
        serializedObject.ApplyModifiedProperties();

    }

    private string addPlusSignIfPositive(int value)
    {
        if(value > 0) return "+" + value ;

        return value.ToString() ; 
    }

    private TMP_Text findTMPComponent(Object parent)
    {
        // Find the canvas first
        var childCanvas= target.GetComponentInChildren<Canvas>();
        if (childCanvas == null)
        {
            Debug.LogWarning("Can't find canvas in the children of " 
                + parent + ". Check if there is a canvas object attached to it");
            return null;
        }

        // Find the TextMeshPro component
        var tmpText = childCanvas.GetComponentInChildren<TMP_Text>();
        if (tmpText == null)
        {
            Debug.LogWarning("Can't find TextMeshPro in the children of "
                + parent + ". Check if there is a canvas object attached to it");
            return null;
        }

        return tmpText;
    }
  
}
