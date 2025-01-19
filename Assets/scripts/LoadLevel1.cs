using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    // Méthode appelée lorsque le bouton est cliqué
    public void LoadLevel1Scene()
    {
        // Charge la scène Level1Scene
        SceneManager.LoadScene("Level1Scene");
    }
}