using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText; 

    
    public void Setup(int score)
    {
        gameObject.SetActive(true); 
        if (pointsText != null) 
        {
            pointsText.text = score.ToString() + " Points"; 
        }
        else
        {
            Debug.LogError("pointsText n'est pas assigné dans l'inspecteur Unity."); 
        }
    }
}
