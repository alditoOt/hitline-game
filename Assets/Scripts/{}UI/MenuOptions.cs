using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenu.Instance.gameIsPaused = false;
        this.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        TimerManager.Instance.DisableSpeedrunTimer();
        GameManager.Instance.BackToMenu();
    }
}
