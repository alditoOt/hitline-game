using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI speedrunTimerText, bloodText;

    private void FixedUpdate()
    {
        UpdateButtonText();
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void BackToMenu()
    {
        GameManager.Instance.BackToMenu();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void StartTimer()
    {
        TimerManager.Instance.BeginTimer();
    }
    public void SetBlood()
    {
        AudioManager.Instance.Play("Shoot");
        VariablesManager.Instance.bloodToggle = !VariablesManager.Instance.bloodToggle;
    }

    public void SetSpeedrunTimer()
    {
        AudioManager.Instance.Play("Shoot");
        VariablesManager.Instance.speedrunTimer = !VariablesManager.Instance.speedrunTimer;
    }

    public void UpdateButtonText()
    {
        if(speedrunTimerText == null || bloodText == null)
        {
            return;
        }
        if(VariablesManager.Instance.speedrunTimer)
        {
            speedrunTimerText.text = "Speedrun timer: yes";
        }
        else
        {
            speedrunTimerText.text = "Speedrun timer: no";
        }
        if(VariablesManager.Instance.bloodToggle)
        {
            bloodText.text = "Show blood: yes";
        }
        else
        {
            bloodText.text = "Show blood: no";
        }
    }

    public void DisableSpeedrunTimer()
    {
        TimerManager.Instance.DisableSpeedrunTimer();
    }
}
