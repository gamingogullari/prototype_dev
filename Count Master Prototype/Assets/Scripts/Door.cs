using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    private int affectCount;

    [SerializeField]
    private GameObject affectTextMeshGO;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player)
        {
            Debug.Log(gameObject.name + " collided with player");
            if(affectCount < 0 )
            {
                player.ShrinkMinionCount(affectCount);
            }
            else
            {
                player.GrowMinionCount(affectCount);
            }
        }
    }

    public void SetAffectCount(int affectCount)
    {
        this.affectCount = affectCount;
    }
}
