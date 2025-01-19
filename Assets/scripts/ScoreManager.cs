using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Pour charger des sc�nes

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton pour acc�der au score depuis d'autres scripts

    public int score = 0; // Variable pour stocker le score
    public TextMeshProUGUI scoreText; // R�f�rence au TextMeshPro pour afficher le score
    public TextMeshProUGUI planetsRemainingText; // R�f�rence au TextMeshPro pour afficher les plan�tes restantes
    public int totalPlanets = 9; // Nombre total de plan�tes
    private int planetsRemaining; // Nombre de plan�tes restantes

    public TextMeshProUGUI pressNText; // R�f�rence au TextMeshPro pour afficher le message "Appuyez sur N"

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

        // D�sactive le texte "Appuyez sur N" au d�marrage
        if (pressNText != null)
        {
            pressNText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // V�rifie si la touche "N" est press�e et si toutes les plan�tes sont r�colt�es
        if (Input.GetKeyDown(KeyCode.N) && planetsRemaining <= 0)
        {
            LoadNextLevel(); // Charge la sc�ne suivante
        }
    }

    // M�thode pour ajouter des points au score
    public void AddScore(int points)
    {
        score += points; // Ajoute les points au score
        UpdateScoreText(); // Met � jour l'affichage du score

        // V�rifie si le joueur a r�colt� toutes les plan�tes
        if (planetsRemaining <= 0)
        {
            EnablePressNText(); // Active le texte "Appuyez sur N"
        }
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

            Debug.Log("Plan�tes restantes : " + planetsRemaining); // Affiche le nombre de plan�tes restantes

            // V�rifie si le joueur a r�colt� toutes les plan�tes
            if (planetsRemaining <= 0)
            {
                EnablePressNText(); // Active le texte "Appuyez sur N"
            }
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

    // M�thode pour activer le texte "Appuyez sur N"
    private void EnablePressNText()
    {
        if (pressNText != null)
        {
            pressNText.gameObject.SetActive(true);
            Debug.Log("Texte 'Appuyez sur N' activ� !"); // Confirme que le texte est activ�
        }
    }

    // M�thode pour charger le niveau suivant
    public void LoadNextLevel()
    {
        Debug.Log("Chargement de la sc�ne suivante..."); // Confirme que la m�thode est appel�e
        SceneManager.LoadScene("Level2Scene"); // Remplacez "Level2Scene" par le nom exact de votre sc�ne
    }
}