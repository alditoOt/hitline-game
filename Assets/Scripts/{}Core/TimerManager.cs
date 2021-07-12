using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerManager : MonoBehaviourSingleton<TimerManager>
{
    public TextMeshProUGUI timerText;

    private bool timerGoing;
    private float startTime;
    private float elapsedTime;
    private float timePlaying;

    public static string minutes, seconds;
    private void Start()
    {
        timerGoing = false;
    }

    private void FixedUpdate()
    {
        if(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            minutes = ((int)elapsedTime / 60).ToString("00");
            seconds = ((int)elapsedTime % 60).ToString("00");
            Debug.Log(minutes + ":" + seconds);
        }
    }
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        //StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        //timerText.text = "Time: " + minutes + ":" + seconds;
    }

    /*IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            yield return new WaitForSecondsRealtime(0.001f);
            elapsedTime += 0.001f;
            minutes = (int)elapsedTime / 60000;
            seconds = (int)elapsedTime / 1000 - 60 * minutes;
            milliseconds = (int)elapsedTime - minutes * 60000 - 1000 * seconds;
            Debug.Log(minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00"));
        }
    }*/

    public void GetText(TextMeshProUGUI text)
    {
        timerText = text;
    }
}
