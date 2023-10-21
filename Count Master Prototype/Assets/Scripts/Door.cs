using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int affectCount = 3;

    [SerializeField]
    private GameObject affectTextMeshGO;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = ScriptableObject.CreateInstance<PlayerController>();    
        var player = other.GetComponent<Player>();
        if (player)
        {
            Debug.Log(gameObject.name + " collided with player");
            if(affectCount < 0 )
            {
                playerController.ShrinkMinionCount(affectCount);
            }
            else
            {
                playerController.GrowMinionCount(affectCount);
            }
        }
    }

    public void SetAffectCount(int affectCount)
    {
        this.affectCount = affectCount;
    }
}
