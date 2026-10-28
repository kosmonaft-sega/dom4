using UnityEngine;

[CreateAssetMenu(fileName = "CharData", menuName = "ScriptableObjects/CharData", order = 0)]
public class CharData : ScriptableObject 
{
    //personal stats
    [SerializeField] private string charName;
    [SerializeField, Min(1)] private int maxHp = 1;
    [SerializeField] private int baseDamage;
    [SerializeField, Min(1)] private int startLevel = 1;
    [SerializeField] private int startXp;
    [SerializeField] private int giveXp;

    //universal stats
    private int maxHunger = 100;
    private int requiredXp = 100;

    //read personal stats
    public string CharName => charName;
    public float MaxHp => maxHp;
    public float BaseDamage => baseDamage;
    public int StartLevel => startLevel;
    public int StartXp => startXp;
    public int GiveXp => giveXp;
    
    //read universal stats
    public int RequiredXp => requiredXp;
    public int MaxHunger => maxHunger;
}
