using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;

[CustomEditor(typeof(MultiplyDoor))]
public class MultiplyDoorEditorScript : Editor
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
        affectValue = serializedObject.FindProperty("affectMultiplier");
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
        EditorGUILayout.Slider(affectValue, 0.5f, 3.0f);

        handleDoorText();
        handleDoorColor(affectValue.floatValue);
        saveChanges();
    }

    private void saveChanges()
    {
        EditorUtility.SetDirty(affectText);
        serializedObject.ApplyModifiedProperties();
    }

    private void handleDoorText()
    {
        affectText.text = addXSign(affectValue.floatValue);
    }

    // Changes the color based on the affectValue
    private void handleDoorColor(float affectValue)
    {
        Material materialToApply;
        if (affectValue > 1)
        {
            materialToApply = plusDoorMaterial;
        }
        else if (affectValue == 1)
        {
            materialToApply = notWorkingDoorMaterial;
        }
        else
        {
            materialToApply = minusDoorMaterial;
        }
        renderer.sharedMaterial = materialToApply;
    }

    private string addXSign(float value)
    {
        // Use only one digit for decimal part
        return "x" + value.ToString();
    }
  
}
