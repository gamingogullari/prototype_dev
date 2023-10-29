using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplyDoor : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private float affectMultiplier;

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
            playerController.MultiplyMinionCount(affectMultiplier);
        }
    }
}
