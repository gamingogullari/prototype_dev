using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;

[CustomEditor(typeof(Door))]
public class DoorAffectEditorScript : Editor
{

    SerializedProperty affectValue;
    private TMP_Text affectText;

    //Door colors
    private Material notWorkingDoorMaterial;
    private Material plusDoorMaterial;
    private Material minusDoorMaterial;
    private Renderer renderer;

    private void OnEnable()
    {
        affectValue = serializedObject.FindProperty("affectCount");
        affectText = findTMPComponent(target);
        loadMaterials();
        renderer = target.GetComponent<Renderer>();
    }

    public override void OnInspectorGUI()
    {
        // Needs to be called before any modifications
        base.OnInspectorGUI();
        serializedObject.Update();

        // Create and use the value of the slider
        EditorGUILayout.IntSlider(affectValue, -100, 100);

        handleDoorText();
        handleDoorColor(affectValue.intValue);
        saveChanges();
    }

    private void saveChanges()
    {
        EditorUtility.SetDirty(affectText);
        serializedObject.ApplyModifiedProperties();
    }

    private void handleDoorText()
    {
        affectText.text = addPlusSignIfPositive(affectValue.intValue);
    }

    // Changes the color based on the affectValue
    private void handleDoorColor(int affectValue)
    {
        Material materialToApply;
        if (affectValue > 0)
        {
            materialToApply = plusDoorMaterial;
        }
        else if (affectValue == 0)
        {
            materialToApply = notWorkingDoorMaterial;
        }
        else
        {
            materialToApply = minusDoorMaterial;
        }
        renderer.sharedMaterial = materialToApply;
    }

    private string addPlusSignIfPositive(int value)
    {
        if(value > 0) return "+" + value ;

        return value.ToString() ; 
    }

    private void loadMaterials()
    {
        notWorkingDoorMaterial = Resources.Load("Material/NotWorkingDoor", typeof(Material)) as Material;
        plusDoorMaterial = Resources.Load("Material/PlusDoor", typeof(Material)) as Material;
        minusDoorMaterial = Resources.Load("Material/MinusDoor", typeof(Material)) as Material;
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
