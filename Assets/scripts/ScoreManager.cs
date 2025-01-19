using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton pour acc�der au score depuis d'autres scripts

    public int score = 0; // Variable pour stocker le score
    public TextMeshProUGUI scoreText; // R�f�rence au TextMeshPro pour afficher le score
    public TextMeshProUGUI planetsRemainingText; // R�f�rence au TextMeshPro pour afficher les plan�tes restantes
    public int totalPlanets = 10; // Nombre total de plan�tes
    private int planetsRemaining; // Nombre de plan�tes restantes

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

        // Initialise le nombre de plan�tes restantes
        planetsRemaining = totalPlanets;
        UpdatePlanetsRemainingText();
    }

    // M�thode pour ajouter des points au score
    public void AddScore(int points)
    {
        score += points; // Ajoute les points au score
        UpdateScoreText(); // Met � jour l'affichage du score
    }

    // M�thode pour mettre � jour l'affichage du score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }

    // M�thode pour diminuer le nombre de plan�tes restantes
    public void DecreasePlanetsRemaining()
    {
        if (planetsRemaining > 0)
        {
            planetsRemaining--; // Diminue le nombre de plan�tes restantes
            UpdatePlanetsRemainingText(); // Met � jour l'affichage
        }
    }

    // M�thode pour mettre � jour l'affichage des plan�tes restantes
    private void UpdatePlanetsRemainingText()
    {
        if (planetsRemainingText != null)
        {
            planetsRemainingText.text = "Il vous reste " + planetsRemaining + "/" + totalPlanets + " plan�tes";
        }
    }
}