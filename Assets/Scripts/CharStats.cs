using System;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] private CharUi charUi;
    public CharData charData;

    private float hp;

    public Action<float> hpChange;
    public Action<CharStats> onDeath;

    public float Hp
    {
        get => hp;
        set
        {
            hp=Mathf.Clamp(value,0,charData.MaxHp);
            hpChange?.Invoke(hp);
            if(hp <= 0)
            {
                onDeath?.Invoke(this);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        Hp = charData.MaxHp;
    }
}
