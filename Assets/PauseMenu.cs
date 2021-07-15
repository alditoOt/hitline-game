using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviourSingleton<PauseMenu>
{
    public bool gameIsPaused = false;
    public GameObject pauseMenu;
    void OnPause()
    {
        if(pauseMenu == null)
        {
            return;
        }
        if(gameIsPaused)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            gameIsPaused = true;
        }
    }

    public void getPauseMenu(GameObject pauseMenu)
    {
        this.pauseMenu = pauseMenu;
    }
}
