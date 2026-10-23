using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharData charData;
    [SerializeField] EnemySpawner enemySpot;

    private List<CharStats> enemyList = new List<CharStats>();

    private void Awake() {
        enemyList = enemySpot.enemyList;
    }

    public void Damage()
    {
        if(enemyList == null)
            return;
        var tempList = new List<CharStats>(enemyList);
        foreach(CharStats enemy in tempList)
        {
            enemy.Hp -= charData.BaseDamage;
        }
    }
}
