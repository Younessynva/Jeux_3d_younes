using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    // M�thode appel�e lorsque le bouton est cliqu�
    public void LoadLevel1Scene()
    {
        // Charge la sc�ne Level1Scene
        SceneManager.LoadScene("Level1Scene");
    }
}