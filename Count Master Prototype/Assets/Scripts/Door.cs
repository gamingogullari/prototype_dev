using TMPro;
using UnityEngine;


public class Door : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private int affectCount;

    [SerializeField, HideInInspector]
    private TMP_Text affectText;

    private bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
            return;

        PlayerController playerController = ScriptableObject.CreateInstance<PlayerController>();    
        var player = other.GetComponent<Player>();
        if (player)
        {
            isActive = false;

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
}
