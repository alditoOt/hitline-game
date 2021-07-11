using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int enemyCount;
    private GameObject openingWall;
    private void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        openingWall = GameObject.FindGameObjectWithTag("OpeningWall");
    }
    public void EnemyDead()
    {
        enemyCount--;
        if(enemyCount <= 0)
        {
            openingWall.SetActive(false);
            Debug.Log("OH MY GOD EVERYONE'S DEAD");
        }
    }

    public void NextFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetEnemyCount(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }

    public void GetOpeningWall(GameObject openingWall)
    {
        this.openingWall = openingWall;
    }
}
