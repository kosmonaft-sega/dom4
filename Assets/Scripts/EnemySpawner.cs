using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private CharStats enemy;
    [SerializeField] private List<CharData> typesOfEnemies;

    public List<CharStats> enemyList = new List<CharStats>();

    public Action<CharStats> attackOneEnemy;
    public Action<int> giveXp;

    private void Start()
    {
        for(int i=0; i<3; i++)
            SpawnEnemy();
    }

    private void OnEnable()
    {
        if(enemyList == null)
            return;
        foreach(CharStats newEnemy in enemyList)
            newEnemy.onDeath += RemoveFromList;
    }

    private void OnDisable()
    {
        if(enemyList == null)
            return;
        foreach(CharStats newEnemy in enemyList)
            newEnemy.onDeath -= RemoveFromList;
    }

    private void SpawnEnemy()
    {
        CharStats newEnemy = Instantiate(enemy,Vector3.zero,Quaternion.identity,transform);
        enemyList.Add(newEnemy);
        newEnemy.charData = typesOfEnemies[UnityEngine.Random.Range(0,typesOfEnemies.Count)]; 
        newEnemy.enemySpawner = this; 
        newEnemy.onDeath += RemoveFromList;
    }

    private void RemoveFromList(CharStats enemyToRemove)
    {
        enemyList.Remove(enemyToRemove);
        giveXp?.Invoke(enemyToRemove.charData.GiveXp);
    }
}
