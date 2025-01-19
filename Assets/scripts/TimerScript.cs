using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public int StartCount = 180; // Temps initial
    private TMP_Text timeText;

    private Coroutine timerCoroutine; // Stocke la référence à la coroutine en cours

    private void Start()
    {
        timeText = GameObject.Find("TimerLevel2").GetComponent<TMP_Text>();
        timerCoroutine = StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        while (StartCount > 0)
        {
            yield return new WaitForSeconds(1f);
            StartCount--;
            UpdateTimerDisplay();
        }

        if (StartCount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Méthode pour réinitialiser le timer
    public void ResetTimer()
    {
        StartCount = 180; // Réinitialise le compteur
        UpdateTimerDisplay(); // Met à jour l'affichage
    }

    // Méthode pour appliquer une pénalité
    public void ApplyPenalty(int penalty)
    {
        StartCount -= penalty;
        if (StartCount < 0) StartCount = 0; // Empêche un temps négatif
        UpdateTimerDisplay();
    }

    // Met à jour le texte de l'affichage du timer
    private void UpdateTimerDisplay()
    {
        timeText.text = "Temps Restant : " + StartCount;
    }
}
