﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int enemyCount;
    private GameObject openingWall;
    private GameObject boss;
    public int finalFloorIndex;

    public GameObject screenTransitionStart;
    public GameObject screenTransitionRestart;
    private void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        openingWall = GameObject.FindGameObjectWithTag("OpeningWall");
    }
    public void EnemyDead()
    {
        enemyCount--;
        if(enemyCount <= 0 && SceneManager.GetActiveScene().buildIndex != finalFloorIndex)
        {
            openingWall.SetActive(false);
            AudioManager.Instance.Play("DoorOpen");
            AudioManager.Instance.Play("AllDead");
            Debug.Log("OH MY GOD EVERYONE'S DEAD");
        }
        else if(enemyCount <= 0 && SceneManager.GetActiveScene().buildIndex == finalFloorIndex)
        {
            boss.SetActive(true);
            finalFloorIndex = 0;
        }
    }

    public void StartGame()
    {
        screenTransitionStart.SetActive(true);
        //SceneManager.LoadScene(1);
    }
    public void NextFloor()
    {
        screenTransitionStart.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartFloor()
    {
        screenTransitionRestart.SetActive(true);
        finalFloorIndex = 9;
    }

    public void BackToMenu()
    {
        screenTransitionStart.SetActive(true);
    }
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

    public void GetScreenTransitions(GameObject screenTransitionStart, GameObject screenTransitionRestart)
    {
        this.screenTransitionStart = screenTransitionStart;
        this.screenTransitionRestart = screenTransitionRestart;
    }

    public void PlayShootAudio()
    {
        AudioManager.Instance.Play("Shoot");
    }
}
