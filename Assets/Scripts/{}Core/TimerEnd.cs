using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerEnd : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private void Start()
    {
        TimerManager.Instance.EndTimer();
        if(VariablesManager.Instance.speedrunTimer)
        {
            timer.text = "You finished the job in\nTime: " + TimerManager.minutes + ":" + TimerManager.seconds + "." + TimerManager.milliseconds;
        }
        else
        {
            timer.text = "We'll let you know when we need you again";
        }
    }
}
