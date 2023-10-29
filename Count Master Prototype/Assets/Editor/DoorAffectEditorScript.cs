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
        affectText = DoorEditorUtils.FindTMPComponent(target);
        DoorEditorUtils.LoadMaterials(
            ref notWorkingDoorMaterial,
            ref plusDoorMaterial,
            ref minusDoorMaterial);
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
  
}
