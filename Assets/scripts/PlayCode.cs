using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCode : MonoBehaviour
{
    public void StartGame()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("Level1Scene");
    }
}
