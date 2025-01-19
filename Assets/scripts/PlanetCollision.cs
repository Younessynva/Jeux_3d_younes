using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    public string planetName; // Nom de la planète (doit correspondre à la liste correcte).

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Trouve le script de gestion des consignes dans la scène.
            PlanetInstructions instructions = Object.FindFirstObjectByType<PlanetInstructions>();

            if (instructions != null)
            {
                instructions.CheckPlanetCollision(planetName);
            }
            else
            {
                Debug.LogError("Aucun objet avec le script PlanetInstructions n’a été trouvé dans la scène !");
            }
        }
    }
}
