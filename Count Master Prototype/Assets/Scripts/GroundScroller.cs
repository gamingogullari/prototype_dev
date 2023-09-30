using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField]
    private GameObject planeA;

    [SerializeField]
    private GameObject planeB;

    [SerializeField]
    private float speed;

    private float planeMoveDist;

    // Start is called before the first frame update
    void Start()
    {
        Collider colA = planeA.GetComponent<Collider>();
        Collider colB = planeB.GetComponent<Collider>();

        planeMoveDist = colA.bounds.extents.z * 4;
    }

    // Update is called once per frame
    void Update()
    {
        planeA.transform.Translate(Vector3.back * speed * Time.deltaTime);
        planeB.transform.Translate(Vector3.back * speed * Time.deltaTime);
        
        if(planeA.transform.position.z < - planeMoveDist / 2f)
        {
            planeA.transform.Translate(Vector3.forward * planeMoveDist);
        }

        if(planeB.transform.position.z < -planeMoveDist / 2f)
        {
            planeB.transform.Translate(Vector3.forward * planeMoveDist);
        }
    }
}
