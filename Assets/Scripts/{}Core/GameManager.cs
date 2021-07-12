using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private int enemyCount;
    private GameObject openingWall;
    private GameObject boss;
    private GameObject screenTransitionStart;
    private GameObject screenTransitionRestart;
    
    public int finalFloorIndex;

    private void Start()
    {
        AudioManager.Instance.Play("Music");
    }
    public void EnemyDead()
    {
        enemyCount--;
        if(enemyCount <= 0 && SceneManager.GetActiveScene().buildIndex != finalFloorIndex)
        {
            openingWall.SetActive(false);
            AudioManager.Instance.Play("DoorOpen");
            //AudioManager.Instance.Play("AllDead");
            Debug.Log("OH MY GOD EVERYONE'S DEAD");
        }
        else if(enemyCount <= 0 && SceneManager.GetActiveScene().buildIndex == finalFloorIndex)
        {
            boss.SetActive(true);
            finalFloorIndex = 0;
        }
    }
    #region Buttons
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        screenTransitionStart.SetActive(true);
        StartCoroutine(ScreenStartTimer(1));
    }
    public void BackToMenu()
    {
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
        finalFloorIndex = 9;
    }
    IEnumerator ScreenStartTimer(int screen)
    {
        yield return new WaitForSeconds(1f);
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

    public void GetScreenTransitions(GameObject screenTransitionStart, GameObject screenTransitionRestart)
    {
        this.screenTransitionStart = screenTransitionStart;
        this.screenTransitionRestart = screenTransitionRestart;
    }
    #endregion
    public void PlayShootAudio()
    {
        AudioManager.Instance.Play("Shoot");
    }
}
