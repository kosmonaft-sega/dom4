using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharUi : MonoBehaviour
{
    [SerializeField] private CharStats charStats;
    [SerializeField] private Button attackButton;

    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text textLevel;

    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider hungerBar;
    [SerializeField] private Slider xpBar;

    public void Start()
    {
        if(charStats.charData.CharName != "You")
            attackButton.interactable = true;

        hpBar.maxValue = charStats.charData.MaxHp;

        hungerBar.maxValue = charStats.charData.MaxHunger;

        nameField.text = charStats.charData.CharName;

        attackButton.onClick.AddListener(charStats.OnAttack);

        charStats.Init();
    }

    private void OnEnable() 
    {
        charStats.hpChange += DrawHp;

        charStats.xpChange += DrawXp;

        charStats.levelChange += DrawLevel;

        charStats.requiredXpChange += DrawRequierdXp;

        charStats.hungerChange += DrawHunger;
    }

    private void OnDisable() 
    {
        charStats.hpChange -= DrawHp;

        charStats.xpChange -= DrawXp;

        charStats.levelChange -= DrawLevel;

        charStats.requiredXpChange -= DrawRequierdXp;
    }

    public void DrawHp(float hp)
    {
        hpBar.value = hp;
    }
    public void DrawHunger(float Hunger)
    {
        hungerBar.value = Hunger;
    }
    public void DrawXp(int xp)
    {
        xpBar.value = xp;
    }
    public void DrawRequierdXp(int MaxXp)
    {
        xpBar.maxValue = MaxXp;
    }
    public void DrawLevel(int level)
    {
        textLevel.text = $"Lv: {level}";
    }
}
