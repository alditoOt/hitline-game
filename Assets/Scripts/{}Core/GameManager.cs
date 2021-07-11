using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private static int enemyCount;
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
}
