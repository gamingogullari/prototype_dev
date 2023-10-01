using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Range(-100, 100)]
    private int affectCount;

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
}
