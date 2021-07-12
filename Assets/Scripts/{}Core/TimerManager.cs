using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerManager : MonoBehaviourSingleton<TimerManager>
{
    public TextMeshProUGUI timerText;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Start()
    {
        timerText.text = "00:00:00";
        timerGoing = false;
    }

    private void FixedUpdate()
    {
        if(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
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
        timerText.text = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
    }

    IEnumerator UpdateTimer()
    {
        if(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
        }
        yield return null;
    }

    public void GetText(TextMeshProUGUI text)
    {
        timerText = text;
    }
}
