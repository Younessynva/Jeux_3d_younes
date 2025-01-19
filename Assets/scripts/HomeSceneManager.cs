using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    // Cette méthode sera appelée lorsque le bouton "Play" est cliqué
    public void OnPlayButtonClicked()
    {
        // Charge la scène Level1Scene
        SceneManager.LoadScene("Level1Scene");
    }
}