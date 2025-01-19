using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton pour accéder au score depuis d'autres scripts

    public int score = 0; // Variable pour stocker le score
    public TextMeshProUGUI scoreText; // Référence au TextMeshPro pour afficher le score
    public TextMeshProUGUI planetsRemainingText; // Référence au TextMeshPro pour afficher les planètes restantes
    public int totalPlanets = 10; // Nombre total de planètes
    private int planetsRemaining; // Nombre de planètes restantes

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

        // Initialise le nombre de planètes restantes
        planetsRemaining = totalPlanets;
        UpdatePlanetsRemainingText();
    }

    // Méthode pour ajouter des points au score
    public void AddScore(int points)
    {
        score += points; // Ajoute les points au score
        UpdateScoreText(); // Met à jour l'affichage du score
    }

    // Méthode pour mettre à jour l'affichage du score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }

    // Méthode pour diminuer le nombre de planètes restantes
    public void DecreasePlanetsRemaining()
    {
        if (planetsRemaining > 0)
        {
            planetsRemaining--; // Diminue le nombre de planètes restantes
            UpdatePlanetsRemainingText(); // Met à jour l'affichage
        }
    }

    // Méthode pour mettre à jour l'affichage des planètes restantes
    private void UpdatePlanetsRemainingText()
    {
        if (planetsRemainingText != null)
        {
            planetsRemainingText.text = "Il vous reste " + planetsRemaining + "/" + totalPlanets + " planètes";
        }
    }
}