using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public int StartCount = 180;
    private TMP_Text timeText;
        private void Start()
    {
        timeText = GameObject.Find("TimerLevel2").GetComponent<TMP_Text>();
        
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        while (StartCount > 0)
        {
            yield return new WaitForSeconds(1f);
            StartCount--;
            timeText.text = "Temps Restant : " + StartCount;
        }
        if (StartCount <= 0)
        {
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}