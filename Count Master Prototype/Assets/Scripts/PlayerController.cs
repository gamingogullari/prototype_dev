using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ScriptableObject
{
    private List<Player> minions = new List<Player>();
    private int activeMinionIndex = 0;

    public void OnEnable()
    { 
        Player player = Player.FindObjectOfType<Player>();
        minions.Add(player);
    }

    public void GrowMinionCount(int count)
    {
        for (int i = 0; i < count; i++) 
        {
            Vector3 minionPos = new Vector3(
                minions[0].transform.position.x + Random.Range(-3.0f, 3.0f), 
                minions[0].transform.position.y, 
                minions[0].transform.position.z + Random.Range(-3.0f, 3.0f));
            AddMinion(minionPos);
        }
        Debug.Log("Gained " + count + " minions");
    }

    private void AddMinion(Vector3 position) 
    {
        if (activeMinionIndex < minions.Count - 1)
        {
            activeMinionIndex++;
            minions[activeMinionIndex].enabled = true;
        }
        else { 
            Player new_instance = Player.Instantiate(minions[0], position, Quaternion.identity);
            minions.Add(new_instance);
        }
        activeMinionIndex++;
    }

    public void ShrinkMinionCount(int count)
    {
        if (minions.Count > count)
        {
            Debug.LogWarning("GAME OVER");
            return;
        }
        for (int i = 0; i < count; i++) 
        {
            RemoveMinion();
        }
        Debug.Log(count + " minions are dead");
    }

    private void RemoveMinion()
    {
        if (activeMinionIndex == 0)
        {
            Debug.LogWarning("GAME OVER");
            return;
        }

        minions[activeMinionIndex].enabled = false;
        activeMinionIndex--;
    }
}
