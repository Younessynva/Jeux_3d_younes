using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float initialTime = 180f; // Temps initial en secondes.
    private float currentTime; // Temps restant.
    public Text timerText; // R�f�rence � un composant Text pour afficher le temps.
    public GameOverScreen gameOverScreen; // R�f�rence � l'�cran de Game Over.

    void Start()
    {
        // Initialise le temps � la valeur de d�part.
        currentTime = initialTime;
        UpdateTimerText();
    }

    void Update()
    {
        // R�duit le temps restant chaque frame.
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            // Si le temps atteint 0, d�clenche le Game Over.
            if (currentTime <= 0)
            {
                currentTime = 0;
                TriggerGameOver();
            }
        }
    }

    public void CorrectPlanetFound()
    {
        // R�initialise le timer � sa valeur initiale.
        currentTime = initialTime;
        UpdateTimerText();
    }

    public void WrongPlanetFound()
    {
        // R�duit le temps de 10 secondes.
        currentTime -= 10f;

        // Emp�che le temps d'�tre n�gatif.
        if (currentTime < 0)
        {
            currentTime = 0;
            TriggerGameOver();
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        // Met � jour l'affichage du timer dans le format MM:SS.
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void TriggerGameOver()
    {
        // Active l'�cran de Game Over.
        gameOverScreen.Setup(Mathf.FloorToInt(currentTime));
        Debug.Log("Game Over! Temps �coul�.");
    }
}
