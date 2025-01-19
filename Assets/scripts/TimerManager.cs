using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance; // Singleton pour acc�der au timer depuis d'autres scripts

    public float timeRemaining = 60f; // Temps initial en secondes
    public TextMeshProUGUI timerText; // R�f�rence au TextMeshPro pour afficher le temps
    public bool isTimerRunning = true; // Indique si le chronom�tre est actif

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
                UpdateTimerDisplay(); // Met � jour l'affichage du temps
            }
            else
            {
                // Le temps est �coul�
                timeRemaining = 0;
                isTimerRunning = false;
                TimerEnded(); // Appelle une m�thode pour g�rer la fin du temps
            }
        }
    }

    // Met � jour l'affichage du temps
    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // M�thode appel�e lorsque le temps est �coul�
    private void TimerEnded()
    {
        Debug.Log("Le temps est �coul� !");
        // Vous pouvez ajouter ici des actions � effectuer lorsque le temps est �coul�
        // Par exemple, afficher un �cran de fin de jeu ou arr�ter le jeu.
    }
}