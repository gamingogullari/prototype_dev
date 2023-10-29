using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DoorEditorUtils : Editor
{
    public static void LoadMaterials(
        ref Material notWorkingMat,
        ref Material plusDoorMat,
        ref Material minusDoorMat)
    {
        notWorkingMat = Resources.Load("Material/NotWorkingDoor", typeof(Material)) as Material;
        plusDoorMat = Resources.Load("Material/PlusDoor", typeof(Material)) as Material;
        minusDoorMat = Resources.Load("Material/MinusDoor", typeof(Material)) as Material;
    }

    public static TMP_Text FindTMPComponent(Object parent)
    {
        // Find the canvas first
        var childCanvas = parent.GetComponentInChildren<Canvas>();
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
