using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Pour charger des scènes

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton pour accéder au score depuis d'autres scripts

    public int score = 0; // Variable pour stocker le score
    public TextMeshProUGUI scoreText; // Référence au TextMeshPro pour afficher le score
    public TextMeshProUGUI planetsRemainingText; // Référence au TextMeshPro pour afficher les planètes restantes
    public int totalPlanets = 9; // Nombre total de planètes
    private int planetsRemaining; // Nombre de planètes restantes

    public TextMeshProUGUI pressNText; // Référence au TextMeshPro pour afficher le message "Appuyez sur N"

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

        // Désactive le texte "Appuyez sur N" au démarrage
        if (pressNText != null)
        {
            pressNText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Vérifie si la touche "N" est pressée et si toutes les planètes sont récoltées
        if (Input.GetKeyDown(KeyCode.N) && planetsRemaining <= 0)
        {
            LoadNextLevel(); // Charge la scène suivante
        }
    }

    // Méthode pour ajouter des points au score
    public void AddScore(int points)
    {
        score += points; // Ajoute les points au score
        UpdateScoreText(); // Met à jour l'affichage du score

        // Vérifie si le joueur a récolté toutes les planètes
        if (planetsRemaining <= 0)
        {
            EnablePressNText(); // Active le texte "Appuyez sur N"
        }
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

            Debug.Log("Planètes restantes : " + planetsRemaining); // Affiche le nombre de planètes restantes

            // Vérifie si le joueur a récolté toutes les planètes
            if (planetsRemaining <= 0)
            {
                EnablePressNText(); // Active le texte "Appuyez sur N"
            }
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

    // Méthode pour activer le texte "Appuyez sur N"
    private void EnablePressNText()
    {
        if (pressNText != null)
        {
            pressNText.gameObject.SetActive(true);
            Debug.Log("Texte 'Appuyez sur N' activé !"); // Confirme que le texte est activé
        }
    }

    // Méthode pour charger le niveau suivant
    public void LoadNextLevel()
    {
        Debug.Log("Chargement de la scène suivante..."); // Confirme que la méthode est appelée
        SceneManager.LoadScene("Level2Scene"); // Remplacez "Level2Scene" par le nom exact de votre scène
    }
}