using UnityEngine;

public class PlanetInfoTrigger : MonoBehaviour
{
    public GameObject infoPopup; // R�f�rence au pop-up d'information

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si c'est le joueur qui entre dans le trigger
        if (other.CompareTag("Player"))
        {
            infoPopup.SetActive(true); // Active le pop-up
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // V�rifie si c'est le joueur qui sort du trigger
        if (other.CompareTag("Player"))
        {
            infoPopup.SetActive(false); // D�sactive le pop-up
        }
    }
}