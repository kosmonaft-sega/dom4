using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharStats charStats;
    [SerializeField] EnemySpawner enemySpot;

    private List<CharStats> enemyList = new List<CharStats>();

    private void Awake() {
        enemyList = enemySpot.enemyList;
    }

    private void OnEnable() {
        enemySpot.attackOneEnemy += DamageOne;
        enemySpot.giveXp += charStats.XpChange;
    }

    private void OnDisable() {
        enemySpot.attackOneEnemy -= DamageOne;
        enemySpot.giveXp -= charStats.XpChange;
    }

    public void Damage() //all baseDamage/3
    {
        if(enemyList == null)
            return;
        var tempList = new List<CharStats>(enemyList);
        foreach(CharStats enemy in tempList)
        {
            enemy.Hp -= charStats.charData.BaseDamage/3;
            charStats.Hp -= enemy.charData.BaseDamage;
        }
    }
    public void DamageOne(CharStats enemy)
    {
        var tempList = new List<CharStats>(enemyList);
        foreach(CharStats _enemy in tempList)
        {
            charStats.Hp -= _enemy.charData.BaseDamage;
        }
        enemy.Hp -= charStats.charData.BaseDamage;
    }

    public void Heal()
    {
        if(charStats.Hunger<=0) return;
        charStats.Hunger -= 20;
        charStats.Hp += 20;
    }

    public void Eat()
    {
        if(charStats.Hunger>=charStats.charData.MaxHunger) return;
        charStats.Hunger += 20;
    }
}
