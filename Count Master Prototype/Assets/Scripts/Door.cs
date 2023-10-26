using UnityEngine;


[System.Serializable]
public class Door : MonoBehaviour
{
    private int affectCount;

    private bool active = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!active)
            return;

        PlayerController playerController = ScriptableObject.CreateInstance<PlayerController>();    
        var player = other.GetComponent<Player>();
        if (player)
        {
            active = false;

            Debug.Log(gameObject.name + " collided with player");
            if(affectCount < 0 )
            {
                //TODO: call with ShrinkMinionCount(affectCount)
                playerController.ShrinkMinionCount(1);
            }
            else
            {
                //TODO: call with GrowMinionCount(affectCount)
                playerController.GrowMinionCount(1);
            }
        }
    }

    public void SetAffectCount(int affectCount)
    {
        this.affectCount = affectCount;
    }
}
