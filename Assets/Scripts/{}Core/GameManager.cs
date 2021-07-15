﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private int enemyCount;
    private GameObject openingWall;
    private GameObject boss;
    private GameObject screenTransitionStart;

    private void Start()
    {
        AudioManager.Instance.Play("Music");
    }
    public void EnemyDead()
    {
        enemyCount--;
        if(boss != null)
        {
            if(enemyCount == 1)
            {
                boss.SetActive(true);
            }
        }
        if (enemyCount <= 0)
        {
            openingWall.SetActive(false);
            AudioManager.Instance.Play("DoorOpen");
            Debug.Log("OH MY GOD EVERYONE'S DEAD");
        }
    }
    #region Buttons
    public void QuitGame()
    {
        AudioManager.Instance.Play("Shoot");
        Application.Quit();
    }
    public void StartGame()
    {
        AudioManager.Instance.Play("Shoot");
        screenTransitionStart.SetActive(true);
        StartCoroutine(ScreenStartTimer(1));
    }
    public void BackToMenu()
    {
        AudioManager.Instance.Play("Shoot");
        screenTransitionStart.SetActive(true);
        StartCoroutine(ScreenStartTimer(0));
    }
    #endregion

    #region LevelManagement
    public void NextFloor()
    {
        screenTransitionStart.SetActive(true);
        StartCoroutine(ScreenStartTimer(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void RestartFloor()
    {
        screenTransitionStart.SetActive(true);
        StartCoroutine(ScreenStartTimer(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator ScreenStartTimer(int screen)
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(screen);
    }
    #endregion

    #region getComponents
    public void GetEnemyCount(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }

    public void GetOpeningWall(GameObject openingWall)
    {
        this.openingWall = openingWall;
    }

    public void GetBoss(GameObject boss)
    {
        this.boss = boss;
    }

    public void GetScreenTransitions(GameObject screenTransitionStart)
    {
        this.screenTransitionStart = screenTransitionStart;
       
    }
    #endregion
    public void PlayShootAudio()
    {
        AudioManager.Instance.Play("Shoot");
    }
}
