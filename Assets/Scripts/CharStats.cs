using System;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] private CharUi charUi;
    public EnemySpawner enemySpawner;
    public CharData charData;

    private float hp;
    private float hunger;
    private int xp;
    private int requiredXp;
    private int level = 1;

    public Action<float> hpChange;
    public Action<float> hungerChange;
    public Action<int> xpChange;
    public Action<int> requiredXpChange;
    public Action<int> levelChange;
    public Action<CharStats> onDeath;

    public float Hp
    {
        get => hp;
        set
        {
            hp = Mathf.Clamp(value,0,charData.MaxHp);
            hpChange?.Invoke(hp);
            if(hp <= 0)
            {
                onDeath?.Invoke(this);
                Destroy(gameObject);
            }
        }
    }

    public float Hunger
    {
        get => hunger;
        set
        {
            hunger = Mathf.Clamp(value,0,charData.MaxHunger);
            hungerChange?.Invoke(hunger);
        }
    }

    public int Xp
    {
        get => xp;
        set
        {
            xp=value;
            while(xp>=requiredXp)
            {
                xp -= requiredXp;
                Level += 1;
            }
            xpChange?.Invoke(xp);
        }
    }

    public int RequiredXp
    {
        get => requiredXp;
        set
        {
            requiredXp=value;
            requiredXpChange?.Invoke(requiredXp);
        }
    }

    public int Level
    {
        get => level;
        set
        {
            level = value;
            RequiredXp *= level;
            levelChange?.Invoke(level);
        }
    }

    public void Init()
    {
        Level = charData.StartLevel;
        RequiredXp = charData.RequiredXp*Level;
        Xp = charData.StartXp;
        Hp = charData.MaxHp;
        Hunger = charData.MaxHunger;
    }

    public void OnAttack()
    {
        enemySpawner.attackOneEnemy(this);
    }

    public void XpChange(int xp)
    {
        Xp += xp;
    }
}
