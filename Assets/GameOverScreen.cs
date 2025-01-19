using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
   public void Setup(int score){
    gameObject.setActive(true);
    pointsText.text = score.ToString() + "Points";
   }
}
