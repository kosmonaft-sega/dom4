using UnityEngine;

[CreateAssetMenu(fileName = "CharData", menuName = "ScriptableObjects/CharData", order = 0)]
public class CharData : ScriptableObject 
{
    [SerializeField] private string charName;
    [SerializeField] private int maxHp;
    [SerializeField] private int baseDamage;

    public string CharName => charName;
    public float MaxHp => maxHp;
    public float BaseDamage => baseDamage;
}
