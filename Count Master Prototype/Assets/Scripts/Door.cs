using TMPro;
using UnityEngine;


[System.Serializable]
public class Door : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private int affectCount;

    private bool active = true;
    private TMP_Text affectText;


    private void Awake()
    {
        affectText = findTMPComponent(this);
    }

    private void Start()
    {
        affectText.text = addPlusSignIfPositive(affectCount);  
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!active)
            return;

        PlayerController playerController = ScriptableObject.CreateInstance<PlayerController>();    
        var player = other.GetComponent<Player>();
        if (player)
        {
            active = false;

            Debug.Log(gameObject.name + " collided with player");
            if(affectCount < 0 )
            {
                //TODO: call with ShrinkMinionCount(affectCount)
                playerController.ShrinkMinionCount(affectCount);
            }
            else
            {
                //TODO: call with GrowMinionCount(affectCount)
                playerController.GrowMinionCount(affectCount);
            }
        }
    }

    private string addPlusSignIfPositive(int value)
    {
        if (value > 0) return "+" + value;

        return value.ToString();
    }

    public void SetAffectCount(int affectCount)
    {
        this.affectCount = affectCount;
    }

    public int GetAffectCount()
    {
        return this.affectCount;
    }

    private TMP_Text findTMPComponent(Door door)
    {
        // Find the canvas first
        var childCanvas = GetComponentInChildren<Canvas>();
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
