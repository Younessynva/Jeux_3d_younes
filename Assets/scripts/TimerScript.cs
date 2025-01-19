using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public int StartCount = 180; // Temps initial
    private TMP_Text timeText;

    private Coroutine timerCoroutine; // Stocke la r�f�rence � la coroutine en cours

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

    // M�thode pour r�initialiser le timer
    public void ResetTimer()
    {
        StartCount = 180; // R�initialise le compteur
        UpdateTimerDisplay(); // Met � jour l'affichage
    }

    // M�thode pour appliquer une p�nalit�
    public void ApplyPenalty(int penalty)
    {
        StartCount -= penalty;
        if (StartCount < 0) StartCount = 0; // Emp�che un temps n�gatif
        UpdateTimerDisplay();
    }

    // Met � jour le texte de l'affichage du timer
    private void UpdateTimerDisplay()
    {
        timeText.text = "Temps Restant : " + StartCount;
    }
}
