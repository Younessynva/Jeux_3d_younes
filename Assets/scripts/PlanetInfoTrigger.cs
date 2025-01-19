using UnityEngine;
using TMPro;

public class PlanetInfoTrigger : MonoBehaviour
{
    public GameObject infoPopup; // R�f�rence au Panel dans l'UI
    public TextMeshProUGUI planetInfoText;  // R�f�rence au TextMeshPro UI

    private void Start()
    {
        // D�sactive le Panel et le texte au d�marrage
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
        Debug.Log("OnTriggerEnter appel� !");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Joueur d�tect� !");
            // V�rifie que les r�f�rences sont valides
            if (infoPopup == null || planetInfoText == null)
            {
                Debug.LogError("R�f�rences manquantes dans PlanetInfoTrigger !");
                return;
            }

            // Active le Panel et le texte
            infoPopup.SetActive(true);
            planetInfoText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit appel� !");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Joueur sorti du trigger !");
            // V�rifie que les r�f�rences sont valides
            if (infoPopup == null || planetInfoText == null)
            {
                Debug.LogError("R�f�rences manquantes dans PlanetInfoTrigger !");
                return;
            }

            // D�sactive le Panel et le texte
            infoPopup.SetActive(false);
            planetInfoText.gameObject.SetActive(false);
        }
    }
}