using UnityEngine;
using TMPro;

public class PlanetInfoTrigger : MonoBehaviour
{
    public GameObject infoPopup; // R�f�rence au Panel dans l'UI
    public TextMeshProUGUI planetInfoText;  // R�f�rence au TextMeshPro UI
    public TextMeshProUGUI pressPText; // R�f�rence au texte "Appuyez sur P"

    private bool isPlayerNear = false; // Indique si le joueur est proche de la plan�te

    private void Start()
    {
        // D�sactive le Panel, le texte et le message "Appuyez sur P" au d�marrage
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
        // V�rifie si c'est le joueur qui entre dans le trigger
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
        // V�rifie si c'est le joueur qui sort du trigger
        if (other.CompareTag("Player"))
        {
            // D�sactive le message "Appuyez sur P"
            if (pressPText != null)
            {
                pressPText.gameObject.SetActive(false);
            }

            // D�sactive le Panel et le texte
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
        // V�rifie si le joueur est proche et appuie sur "P"
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

            // D�sactive le message "Appuyez sur P"
            if (pressPText != null)
            {
                pressPText.gameObject.SetActive(false);
            }
        }
    }
}