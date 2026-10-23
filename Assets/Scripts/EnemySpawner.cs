using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private CharStats enemy;
    [SerializeField] private List<CharData> typesOfEnemies;

    public List<CharStats> enemyList = new List<CharStats>();

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
        newEnemy.charData = typesOfEnemies[Random.Range(0,typesOfEnemies.Count)]; 
        newEnemy.onDeath += RemoveFromList;
    }

    private void RemoveFromList(CharStats enemyToRemove)
    {
        enemyList.Remove(enemyToRemove);
    }
}
