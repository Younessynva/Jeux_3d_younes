using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInstructions : MonoBehaviour
{
    
    public TMP_Text instructionText; // R�f�rence au texte pour afficher les consignes.
    private int currentInstructionIndex = 0; // Indice de la consigne actuelle.

    // Liste des consignes et des bonnes r�ponses.
    private string[] instructions =
    {
        "Les consignes de ce niveau vous seront indiquees ici a chaque etape. Vous devez toucher le bon element pour repondre a la question. Une nouvelle question vous sera alors posee ici.           1ere Question : Qui est une etoile naine jaune ?", // Soleil
        "Quel est le seul corps celeste visite par l'Homme ?", // Lune
        "Quelle planete a un diametre d'environ 9 fois celui de la Terre ?", // Saturn
        "Quelle planete est habite ?", // Terre
        "Quelle planete a 79 lunes ?", // Jupiter
        "Quelle planete a son atmosphere composee quasiment que de dioxyde de carbone ?", // Mars
        "Quelle planete est composee principalement d'hydrogene ?", // Neptune
        "Quelle planete n'a quasiment pas d'atmosphere ?", // Mercure
        "Quelle planete a une inclinaison de 98%, la faisant rouler sur son orbite ?", // Uranus
        "Quelle planete a un diametre quasi-identique a celui de la Terre ?" // Venus
    };
    private string[] correctPlanets = { "Sun", "Moon", "Saturn", "Earth", "Jupiter", "Mars", "Neptune", "Mercury", "Uranus", "Venus" }; // Noms des plan�tes correctes.

    private TimerScript timerScript; // R�f�rence au TimerScript

    void Start()
    {
        // Trouve le TimerScript dans la sc�ne
        timerScript = FindFirstObjectByType<TimerScript>();
        
        // Initialise avec la premi�re consigne.
        instructionText.text = instructions[currentInstructionIndex];
    }

    public void CheckPlanetCollision(string planetName)
    {
        // V�rifie si le joueur a trouv� la bonne plan�te.
        if (planetName == correctPlanets[currentInstructionIndex])
        {
            Debug.Log($"Bonne reponse : {planetName}");

            // Passe � la consigne suivante.
            currentInstructionIndex++;

            // R�initialise le timer
            timerScript.ResetTimer();

            if (currentInstructionIndex < instructions.Length)
            {
                // Affiche la prochaine consigne.
                instructionText.text = instructions[currentInstructionIndex];
            }
            else
            {
                // Toutes les consignes ont �t� r�solues.
                instructionText.text = "Bravo ! Vous avez trouve toutes les planetes.";
            }
        }
        else
        {
            Debug.Log($"Mauvaise r�ponse : {planetName}");
            // Ne change pas la consigne.
            timerScript.ApplyPenalty(10); // Applique une p�nalit� de 10 secondes
        }
    }
}
