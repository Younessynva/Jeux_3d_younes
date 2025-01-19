using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float initialTime = 180f; // Temps initial en secondes.
    private float currentTime; // Temps restant.
    public Text timerText; // Référence à un composant Text pour afficher le temps.
    public GameOverScreen gameOverScreen; // Référence à l'écran de Game Over.

    void Start()
    {
        // Initialise le temps à la valeur de départ.
        currentTime = initialTime;
        UpdateTimerText();
    }

    void Update()
    {
        // Réduit le temps restant chaque frame.
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            // Si le temps atteint 0, déclenche le Game Over.
            if (currentTime <= 0)
            {
                currentTime = 0;
                TriggerGameOver();
            }
        }
    }

    public void CorrectPlanetFound()
    {
        // Réinitialise le timer à sa valeur initiale.
        currentTime = initialTime;
        UpdateTimerText();
    }

    public void WrongPlanetFound()
    {
        // Réduit le temps de 10 secondes.
        currentTime -= 10f;

        // Empêche le temps d'être négatif.
        if (currentTime < 0)
        {
            currentTime = 0;
            TriggerGameOver();
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        // Met à jour l'affichage du timer dans le format MM:SS.
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void TriggerGameOver()
    {
        // Active l'écran de Game Over.
        gameOverScreen.Setup(Mathf.FloorToInt(currentTime));
        Debug.Log("Game Over! Temps écoulé.");
    }
}
