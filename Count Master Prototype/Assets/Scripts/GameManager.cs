using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{

    public float scrollSpeed;
    public void OnPlayClickHandler()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}

