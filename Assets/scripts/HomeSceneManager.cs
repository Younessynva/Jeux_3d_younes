using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    // Cette m�thode sera appel�e lorsque le bouton "Play" est cliqu�
    public void OnPlayButtonClicked()
    {
        // Charge la sc�ne Level1Scene
        SceneManager.LoadScene("Level1Scene");
    }
}