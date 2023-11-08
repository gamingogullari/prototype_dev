using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAffector : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + this);
    }
}
