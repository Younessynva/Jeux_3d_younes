using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance; // Singleton pour accéder au timer depuis d'autres scripts

    public float timeRemaining = 60f; // Temps initial en secondes
    public TextMeshProUGUI timerText; // Référence au TextMeshPro pour afficher le temps
    public bool isTimerRunning = true; // Indique si le chronomètre est actif

    private void Awake()
    {
        // Configure le singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Diminue le temps restant
                UpdateTimerDisplay(); // Met à jour l'affichage du temps
            }
            else
            {
                // Le temps est écoulé
                timeRemaining = 0;
                isTimerRunning = false;
                TimerEnded(); // Appelle une méthode pour gérer la fin du temps
            }
        }
    }

    // Met à jour l'affichage du temps
    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Méthode appelée lorsque le temps est écoulé
    private void TimerEnded()
    {
        Debug.Log("Le temps est écoulé !");
        // Vous pouvez ajouter ici des actions à effectuer lorsque le temps est écoulé
        // Par exemple, afficher un écran de fin de jeu ou arrêter le jeu.
    }
}