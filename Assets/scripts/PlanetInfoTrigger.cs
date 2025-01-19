using UnityEngine;
using TMPro;

public class PlanetInfoTrigger : MonoBehaviour
{
    public GameObject infoPopup; // Référence au Panel dans l'UI
    public TextMeshProUGUI planetInfoText;  // Référence au TextMeshPro UI

    private void Start()
    {
        // Désactive le Panel et le texte au démarrage
        if (infoPopup != null)
        {
            infoPopup.SetActive(false);
        }
        if (planetInfoText != null)
        {
            planetInfoText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter appelé !");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Joueur détecté !");
            // Vérifie que les références sont valides
            if (infoPopup == null || planetInfoText == null)
            {
                Debug.LogError("Références manquantes dans PlanetInfoTrigger !");
                return;
            }

            // Active le Panel et le texte
            infoPopup.SetActive(true);
            planetInfoText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit appelé !");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Joueur sorti du trigger !");
            // Vérifie que les références sont valides
            if (infoPopup == null || planetInfoText == null)
            {
                Debug.LogError("Références manquantes dans PlanetInfoTrigger !");
                return;
            }

            // Désactive le Panel et le texte
            infoPopup.SetActive(false);
            planetInfoText.gameObject.SetActive(false);
        }
    }
}