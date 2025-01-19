using UnityEngine;
using TMPro;

public class PlanetInfoTrigger : MonoBehaviour // Pas de 'private' ici
{
    public GameObject infoPopup; // Référence au Panel dans l'UI
    public TextMeshProUGUI planetInfoText;  // Référence au TextMeshPro UI
    public TextMeshProUGUI pressPText; // Référence au texte "Appuyez sur P"
    public int scorePoints = 10; // Points attribués pour cette planète

    private bool isPlayerNear = false; // Indique si le joueur est proche de la planète
    private bool hasInteracted = false; // Indique si le joueur a déjà interagi avec la planète

    private void Start()
    {
        // Désactive le Panel, le texte et le message "Appuyez sur P" au démarrage
        if (infoPopup != null)
        {
            infoPopup.SetActive(false);
        }
        if (planetInfoText != null)
        {
            planetInfoText.gameObject.SetActive(false);
        }
        if (pressPText != null)
        {
            pressPText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur qui entre dans le trigger
        if (other.CompareTag("Player"))
        {
            // Active le message "Appuyez sur P"
            if (pressPText != null)
            {
                pressPText.gameObject.SetActive(true);
            }

            // Indique que le joueur est proche
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Vérifie si c'est le joueur qui sort du trigger
        if (other.CompareTag("Player"))
        {
            // Désactive le message "Appuyez sur P"
            if (pressPText != null)
            {
                pressPText.gameObject.SetActive(false);
            }

            // Désactive le Panel et le texte
            if (infoPopup != null)
            {
                infoPopup.SetActive(false);
            }
            if (planetInfoText != null)
            {
                planetInfoText.gameObject.SetActive(false);
            }

            // Indique que le joueur n'est plus proche
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        // Vérifie si le joueur est proche et appuie sur "P"
        if (isPlayerNear && Input.GetKeyDown(KeyCode.P))
        {
            // Active le Panel et le texte
            if (infoPopup != null)
            {
                infoPopup.SetActive(true);
            }
            if (planetInfoText != null)
            {
                planetInfoText.gameObject.SetActive(true);
            }

            // Désactive le message "Appuyez sur P"
            if (pressPText != null)
            {
                pressPText.gameObject.SetActive(false);
            }

            // Ajoute des points au score seulement si le joueur n'a pas déjà interagi
            if (!hasInteracted)
            {
                ScoreManager.Instance.AddScore(scorePoints);
                ScoreManager.Instance.DecreasePlanetsRemaining(); // Diminue le nombre de planètes restantes
                hasInteracted = true; // Marque la planète comme déjà interagie
            }
        }
    }
}