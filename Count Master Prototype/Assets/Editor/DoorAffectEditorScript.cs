using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;

[CustomEditor(typeof(Door))]
public class DoorAffectEditorScript : Editor
{

    int slideValue;
    private Door door;
    private TMP_Text affectText;


    private void OnEnable()
    {
        door = target.GetComponent<Door>();
        affectText = findTMPComponent(door);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Affect Value", EditorStyles.boldLabel);
        slideValue = EditorGUILayout.IntSlider(slideValue, -100, 100);
        affectText.text = addPlusSignIfPositive(slideValue);
        door.SetAffectCount(slideValue);
        EditorGUILayout.EndHorizontal();
        EditorUtility.SetDirty(target);
        EditorUtility.SetDirty(door);
    }

    private string addPlusSignIfPositive(int value)
    {
        if(value > 0) return "+" + value ;

        return value.ToString() ; 
    }

    private TMP_Text findTMPComponent(Door door)
    {
        // Find the canvas first
        var childCanvas= target.GetComponentInChildren<Canvas>();
        if (childCanvas == null)
        {
            Debug.LogWarning("Can't find canvas in the children of " 
                + door.gameObject + ". Check if there is a canvas object attached to it");
            return null;
        }

        // Find the TextMeshPro component
        var tmpText = childCanvas.GetComponentInChildren<TMP_Text>();
        if (tmpText == null)
        {
            Debug.LogWarning("Can't find canvas in the children of "
                + door.gameObject + ". Check if there is a canvas object attached to it");
            return null;
        }

        return tmpText;
    }
  
}
