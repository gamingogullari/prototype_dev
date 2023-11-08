using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField]
    private Animator spikesAnimator;

    [SerializeField]
    private float activationInterval = 2.0f;

    private float lastActivatedAt;

    // Start is called before the first frame update
    void Start()
    {
        lastActivatedAt = Time.time + activationInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastActivatedAt < Time.time)
        {
            activate();
        }
    }

    void activate()
    {
        spikesAnimator.SetTrigger("MoveUp");
        lastActivatedAt = Time.time + activationInterval;
    }
}
