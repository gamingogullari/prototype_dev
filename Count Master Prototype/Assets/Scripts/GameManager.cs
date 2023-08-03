using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    public void OnPlayClickHandler()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}

