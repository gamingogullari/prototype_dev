using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject planeA;

    [SerializeField]
    private GameObject planeB;

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
