using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerManager : MonoBehaviourSingleton<TimerManager>
{
    public TextMeshProUGUI timerText;
    public GameObject speedrunTimer;

    private bool timerGoing;
    private float elapsedTime;

    public static string minutes, seconds, milliseconds;
    private void Start()
    {
        timerGoing = false;
        if(speedrunTimer != null)
        {
            DontDestroyOnLoad(speedrunTimer);
        }
    }

    private void FixedUpdate()
    {
        if(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            minutes = ((int)elapsedTime / 60).ToString("00");
            seconds = ((int)elapsedTime % 60).ToString("00");
            milliseconds = ((int)((elapsedTime - Mathf.Floor(elapsedTime))*1000)).ToString("00");
            Debug.Log(minutes + ":" + seconds + "." + milliseconds);
            timerText.text = minutes + ":" + seconds + "." + milliseconds;
        }
    }
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        if(VariablesManager.Instance.speedrunTimer)
        {
            speedrunTimer.SetActive(true);
        }
        else
        {
            speedrunTimer.SetActive(false);
        }
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public void DisableSpeedrunTimer()
    {
        speedrunTimer.SetActive(false);
    }

    public void EnableSpeedrunTimer()
    {
        speedrunTimer.SetActive(true);
    }
}
