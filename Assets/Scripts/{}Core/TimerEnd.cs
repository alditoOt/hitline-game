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
        timer.text = "Time: " + TimerManager.minutes + ":" + TimerManager.seconds + "." + TimerManager.milliseconds;
    }
}
