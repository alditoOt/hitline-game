using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnd : MonoBehaviour
{
    private void Start()
    {
        TimerManager.Instance.EndTimer();
    }
}
