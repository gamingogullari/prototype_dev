using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * GameManager.Instance.scrollSpeed);
    }
}
